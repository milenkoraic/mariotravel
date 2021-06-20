using System.Collections.Generic;

namespace MarioTravel.Admin.Models.Tour
{
    public class Tours : TourPreview
    {
        public List<TourImage> Images { get; } = new List<TourImage>();
        public TourType Type { get; set; }
        public new decimal? DiscountPercent { get; set; }
        public string Content { get; set; }
        public string IsIncluded { get; set; }
        public string NotIncluded { get; set; }
        public string Language { get; set; }
        public int MinutesBeforeDisposed { get; set; }
    }
}