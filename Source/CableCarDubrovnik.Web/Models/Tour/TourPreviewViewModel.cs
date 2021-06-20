using EnsureThat;

namespace CableCarDubrovnik.Web.Models.Tour
{
    public class TourPreviewViewModel
    {
        public TourPreviewViewModel(
            int id,
            string title,
            string description,
            string displayPrice,
            string displayChildPrice,
            string displayDepartureTimes,
            string displayDuration,
            TourImageViewModel mainImageVm,
            string slug,
            string discountPercent)
        {
            Id = id;
            DisplayDepartureTimes = displayDepartureTimes;
            MainImage = mainImageVm;
            Title = EnsureArg.IsNotNullOrEmpty(title, nameof(title));
            DisplayPrice = EnsureArg.IsNotNullOrEmpty(displayPrice, nameof(displayPrice));
            DisplayDuration = EnsureArg.IsNotNullOrEmpty(displayDuration, nameof(displayDuration));
            DisplayChildPrice = displayChildPrice;
            Description = EnsureArg.IsNotNullOrEmpty(description, nameof(description));
            Slug = EnsureArg.IsNotNullOrEmpty(slug, nameof(slug));
            DiscountPercent = discountPercent;
        }

        public int Id { get; }
        public string Title { get; }
        public string DisplayPrice { get; }
        public string DisplayChildPrice { get; }
        public string DisplayDepartureTimes { get; }
        public string DisplayDuration { get; }
        public TourImageViewModel MainImage { get; }
        public string Description { get; }
        public string Slug { get; }
        public string DiscountPercent { get; set; }
    }
}