using DubrovnikTours.Web.Models.Transfer;
using EnsureThat;
using MarioTravel.Core.BLL.Services.Email.Service;
using MarioTravel.Core.BLL.Services.EmailTemplate.Service.TemplateResources;
using MarioTravel.Core.Configuration.Emails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DubrovnikTours.Web.Controllers.TransferRequests
{
    [ApiController]
    public class SendTransferRequest : ControllerBase
    {
        private readonly EmailSender emailSender;
        private readonly IStringLocalizer<EmailBodyResources> localizer;
        private readonly ILogger<ContactUsController> logger;
        private readonly EmailAddress emailAddress;

        public SendTransferRequest(
                EmailSender emailSender,
                IOptions<EmailAddress> emailAddressAccessor,
                ILogger<ContactUsController> logger,
                IStringLocalizer<EmailBodyResources> localizer)
        {
            if (emailAddressAccessor == null)
            {
                throw new ArgumentNullException(nameof(emailAddressAccessor));
            }

            this.emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            this.localizer = EnsureArg.IsNotNull(localizer, nameof(localizer));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            emailAddress = emailAddressAccessor.Value;
        }

        [Route("api/booking/transfer/request")]
        public async Task<IActionResult> Submit([FromBody] TransferBookingViewModel model)
        {
            try
            {
                var subject = $"NEW TRANSFER REQUEST";
                var messageBuilder = new StringBuilder();

                messageBuilder.AppendLine($"<h2><b>{localizer["TRANSFER REQUEST</b>"]}</b></h2>");
                messageBuilder.AppendLine($"<p>{localizer["Full name"]}: <b>{model.FullName}</b></p>");
                messageBuilder.AppendLine($"<p>{localizer["Phone"]}: <b>{model.Phone}</b></p>");
                messageBuilder.AppendLine($"<p>{localizer["E-mail"]}: <b>{model.Email}</b></p>");
                messageBuilder.AppendLine($"<p>{localizer["From"]}: <b>{model.FromLocation}</b></p>");
                messageBuilder.AppendLine($"<p>{localizer["To"]}: <b>{model.ToLocation}</b></p>");
                messageBuilder.AppendLine($"<p>{localizer["Distance"]}: <b>{model.TransferDistance}</b></p>");
                messageBuilder.AppendLine($"<p>{localizer["Duration"]}: <b>{model.TransferDuration}</b></p>");
                messageBuilder.AppendLine($"<p>{localizer["Date"]}: <b>{model.Date}</b></p>");
                messageBuilder.AppendLine($"<p>{localizer["Time"]}: <b>{model.Time}</b></p>");
                messageBuilder.AppendLine($"<p>{localizer["Number of persons"]}: <b>{model.NumberOfPeople}</b></p>");
                messageBuilder.AppendLine($"<p>{localizer["Additional info (optional)"]}: <b>{model.AdditionalInfo}</b></p>");

                await emailSender.SendEmailAsync(emailAddress.ContactUsFrom, emailAddress.ContactUsTo, subject, messageBuilder.ToString());
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An exception occurred while sending the email.");
                return StatusCode(500);
            }
        }
    }
}