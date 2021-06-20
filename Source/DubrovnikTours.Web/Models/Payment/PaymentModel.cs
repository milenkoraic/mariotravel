using Newtonsoft.Json;

namespace DubrovnikTours.Web.Models.Payment
{
    public class PaymentModel
    {
        [JsonProperty("payment_id")]
        public string PaymentId { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("receipt_url")]
        public string ReceiptUrl { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("approval_code")]
        public string ApprovalCode { get; set; }

        [JsonProperty("processing_code")]
        public string ProcessingCode { get; set; }

        [JsonProperty("card_brand")]
        public string CardBrand { get; set; }

        [JsonProperty("card_masked_pan")]
        public string CardMaskedPan { get; set; }

        [JsonProperty("card_cardholder_name")]
        public string CardCardholderName { get; set; }

        [JsonProperty("card_fingerprint")]
        public string CardFingerprint { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("signature_order")]
        public string SignatureOrder { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
}