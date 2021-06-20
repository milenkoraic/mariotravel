namespace MarioTravel.Admin.Models.Tour
{
    public class TourPriceInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Duration { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? PriceBase { get; set; }
        public decimal PricePerPerson { get; set; }
        public decimal PricePerChild { get; set; }
        public TourImage MainImage { get; set; }
    }
}