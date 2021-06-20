using CableCarDubrovnik.Web.Models.Models;
using System.Collections.Generic;

namespace CableCarDubrovnik.Web.Models.Tour
{
    public class TourViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string IsIncluded { get; set; }
        public string NotIncluded { get; set; }
        public string Type { get; set; }
        public string DisplayDepartureTimes { get; set; }
        public string MinutesBeforeDisposed { get; set; }
        public string DisplayPrice { get; set; }
        public string DisplayChildPrice { get; set; }
        public string DisplayDuration { get; set; }
        public string TimeNesting { get; set; }
        public string PaymentEndpoint { get; set; }
        public string PaymentCallbackEndpoint { get; set; }
        public string PaymentLanguage { get; set; }
        public IEnumerable<TourImageViewModel> Images { get; set; }

        public TourBookingViewModel BookingModel { get; set; }
        public decimal? DiscountPercent { get; set; }
        public Dictionary<int, IEnumerable<Vacation>> Vacations { get; set; }
        public bool InactiveDuringVacation { get; set; }
    }
}