using System.Collections.Generic;

namespace DubrovnikTours.Web.Models.Transfer
{
    public class TransferViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PaymentEndpoint { get; set; }
        public string PaymentCallbackEndpoint { get; set; }
        public string PaymentLanguage { get; set; }

        public TransferBookingViewModel BookingModel { get; set; }
        public AirportBookingViewModel AirportBookingModel { get; set; }
        public decimal? DiscountPercent { get; set; }
        public Dictionary<int, IEnumerable<Vacation>> Vacations { get; set; }
        public bool InactiveDuringVacation { get; set; }
        public int ApplicationId { get; set; }
    }
}