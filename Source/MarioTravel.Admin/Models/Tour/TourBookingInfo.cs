using System.Collections.Generic;

namespace MarioTravel.Admin.Models.Tour
{
    public class TourBookingInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public TourType TourType { get; set; }
        public List<TourTime> TourTimes { get; set; } = new List<TourTime>();
    }
}