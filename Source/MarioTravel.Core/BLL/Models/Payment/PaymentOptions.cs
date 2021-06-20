namespace MarioTravel.Core.BLL.Models.Payment
{
    public class PaymentOptions
    {
        public string Endpoint { get; set; }
        public string CallbackEndpoint { get; set; }
        public string PrivateKey { get; set; }
    }
}