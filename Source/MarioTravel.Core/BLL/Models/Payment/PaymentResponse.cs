using System;

namespace MarioTravel.Core.BLL.Models.Payment
{
    public class PaymentResponse
    {
        public Guid BookingExternalId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string ReceiptUrl { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string ApprovalCode { get; set; }
        public string ProcessingCode { get; set; }
        public string CardBrand { get; set; }
        public string CardMaskedPan { get; set; }
        public string CardCardholderName { get; set; }
        public string SignatureOrder { get; set; }
        public string Signature { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ExternalCreatedAt { get; set; }
        public Guid? CardFingerprint { get; set; }
        public Guid ExternalPaymentId { get; set; }

        // raw string data used for signature verification
        public RawPaymentData Raw { get; set; }

        public int ApplicationId { get; set; }
    }
}