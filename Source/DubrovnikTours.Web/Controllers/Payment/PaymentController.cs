using DubrovnikTours.Web.Models.Payment;
using EnsureThat;
using MarioTravel.Core.BLL.Models.Payment;
using MarioTravel.Core.BLL.Services.Notification.Service;
using MarioTravel.Core.BLL.Services.Payment.Service;
using MarioTravel.Core.Configuration.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace DubrovnikTours.Web.Controllers.Payment
{
    [Route("api/payment")]
    public class PaymentController : Controller
    {
        private readonly AsyncDuplicateLock namedDuplicateLock = new AsyncDuplicateLock();
        private readonly PaymentService paymentService;
        private readonly TourBookingNotificationService tourBookingNotificationService;
        private readonly TransferBookingNotificationService transferBookingNotificationService;

        // bizzarely enough, this is different from the AgentCash POST back field which is external_id
        private const string EXTERNAL_ID_KEY = "externalId";

        public PaymentController(
            PaymentService paymentService,
            TourBookingNotificationService tourBookingNotificationService,
            TransferBookingNotificationService transferBookingNotificationService)
        {
            this.paymentService = EnsureArg.IsNotNull(paymentService, nameof(paymentService));
            this.tourBookingNotificationService = EnsureArg.IsNotNull(tourBookingNotificationService, nameof(tourBookingNotificationService));
            this.transferBookingNotificationService = EnsureArg.IsNotNull(transferBookingNotificationService, nameof(transferBookingNotificationService));
        }

        [HttpPost("finish")]
        public async Task<StatusCodeResult> Finish([FromBody]JObject obj)
        {
            if (obj == null) return new OkResult();
            var externalIdString = (string)obj[EXTERNAL_ID_KEY];

            if (string.IsNullOrEmpty(externalIdString)) return new OkResult();

            if (!Guid.TryParse(externalIdString, out var externalId)) return new OkResult();

            var paymentReceivedData = new PaymentReceived
            {
                ExternalId = externalId,
                RawPaymentResponse = obj.ToString(Formatting.None)
            };

            await paymentService.ConfirmTourPaymentRequestReceived(paymentReceivedData);
            await paymentService.ConfirmTransferPaymentRequestReceived(paymentReceivedData);

            return new OkResult();
        }

        [HttpPost("callback")]
        public async Task<StatusCodeResult> Callback([FromBody]PaymentModel model)
        {
            var rawPaymentData = new RawPaymentData
            {
                CardFingerprint = model.CardFingerprint,
                Status = model.Status,
                Amount = model.Amount,
                CardBrand = model.CardBrand,
                ExternalId = model.ExternalId,
                ApprovalCode = model.ApprovalCode,
                Type = model.Type,
                PaymentId = model.PaymentId,
                CardCardholderName = model.CardCardholderName,
                ProcessingCode = model.ProcessingCode,
                Currency = model.Currency,
                Signature = model.Signature,
                SignatureOrder = model.SignatureOrder,
                ReceiptUrl = model.ReceiptUrl,
                CardMaskedPan = model.CardMaskedPan,
                CreatedAt = model.CreatedAt
            };

            decimal.TryParse(model.Amount, out var amount);

            var payment = new PaymentResponse
            {
                Raw = rawPaymentData,
                CardFingerprint = !string.IsNullOrEmpty(model.CardFingerprint)
                    ? new Guid(model.CardFingerprint)
                    : (Guid?)null,
                Status = model.Status,
                Amount = amount,
                CardBrand = model.CardBrand,
                BookingExternalId = new Guid(model.ExternalId), //TODO: convert to Guid if OK
                ApprovalCode = model.ApprovalCode,
                Type = model.Type,
                ExternalPaymentId = new Guid(model.PaymentId),
                CardCardholderName = model.CardCardholderName,
                ProcessingCode = model.ProcessingCode,
                Currency = model.Currency,
                Signature = model.Signature,
                SignatureOrder = model.SignatureOrder,
                ReceiptUrl = model.ReceiptUrl,
                CardMaskedPan = model.CardMaskedPan,
                ExternalCreatedAt = !string.IsNullOrEmpty(model.CreatedAt) ? DateTime.Parse(model.CreatedAt).ToUniversalTime() : (DateTime?)null,
                CreatedAt = DateTime.UtcNow
            };

            // TODO: consider moving all this logic to send booking notification method.
            using (await namedDuplicateLock.LockAsync(model.ExternalId))
            {
                // Need to check for duplicates and lock on external id because agentcash can sometimes POST several
                // responses for the same payment simultaneously
                if (await paymentService.NotDuplicateAsync(payment.BookingExternalId))
                {
                    var tourPaymentValid = await paymentService.ProcessTourPaymentResponse(payment);
                    var transferPaymentValid = await paymentService.ProcessTransferPaymentResponse(payment);

                    var bookingTourNotification = await tourBookingNotificationService.GetTourBookingNotificationAsync(payment.BookingExternalId);
                    var bookingTransferNotification = await transferBookingNotificationService.GetTransferBookingNotificationAsync(payment.BookingExternalId);
                    
                    if (tourPaymentValid)
                    {
                        if (bookingTourNotification != null)
                        {
                            await tourBookingNotificationService.SendTourBookingNotificationEmailAsync(payment.BookingExternalId);
                        }
                    }
                    else if (transferPaymentValid)
                    {
                        if (bookingTransferNotification != null)
                        {
                            await transferBookingNotificationService.SendTransferBookingNotificationEmailAsync(payment.BookingExternalId);
                        }

                    }
                }
            }

            return new OkResult();
        }
    }
}