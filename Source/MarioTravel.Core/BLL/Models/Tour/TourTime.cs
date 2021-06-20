using System;

namespace MarioTravel.Core.BLL.Models.Tour
{
    public class TourTime
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public TimeSpan StartAt { get; set; }
    }
}