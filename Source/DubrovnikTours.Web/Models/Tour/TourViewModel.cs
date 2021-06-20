using System.Collections.Generic;

namespace DubrovnikTours.Web.Models.Tour
{
    public class TourViewModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string IsIncluded { get; set; }
        public string NotIncluded { get; set; }
        public string DisplayDepartureTimes { get; set; }
        public string DisplayPrice { get; set; }
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
        public int ApplicationId { get; set; }
    }
}