using System.Collections.Generic;

namespace MarioTravel.Core.BLL.Models.Tour
{
    public class TourPreview
    {
        public TourImage MainImage { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public decimal? PriceBase { get; set; }
        public decimal PricePerPerson { get; set; }
        public decimal Duration { get; set; }
        public List<TourTime> TourTimes { get; } = new List<TourTime>();
        public string Slug { get; set; }
        public string TimeNesting { get; set; }
        public decimal? DiscountPercent { get; set; }
        public int LanguageId { get; set; }
        public decimal PricePerChild { get; set; }
        public int ApplicationId { get; set; }
    }
}