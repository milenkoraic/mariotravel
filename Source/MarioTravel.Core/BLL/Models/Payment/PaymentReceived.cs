using System;

namespace MarioTravel.Core.BLL.Models.Payment
{
    public class PaymentReceived
    {
        public string RawPaymentResponse { get; set; }
        public Guid ExternalId { get; set; }
    }
}