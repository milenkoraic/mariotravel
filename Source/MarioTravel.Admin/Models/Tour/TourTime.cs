using System;

namespace MarioTravel.Admin.Models.Tour
{
    public class TourTime
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public int TourType { get; set; }
        public TimeSpan StartAt { get; set; }
        public int MinutesBeforeDisposed { get; set; }
    }
}