namespace MarioTravel.Core.BLL.Models.Payment
{
    public class RawPaymentData
    {
        public string PaymentId { get; set; }
        public string ExternalId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string ReceiptUrl { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string ApprovalCode { get; set; }
        public string ProcessingCode { get; set; }
        public string CardBrand { get; set; }
        public string CardMaskedPan { get; set; }
        public string CardCardholderName { get; set; }
        public string CardFingerprint { get; set; }
        public string CreatedAt { get; set; }
        public string SignatureOrder { get; set; }
        public string Signature { get; set; }
    }
}