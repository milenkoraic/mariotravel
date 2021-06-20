using EnsureThat;

namespace DubrovnikTours.Web.Models.Tour
{
    public class TourPreviewViewModel
    {
        public TourPreviewViewModel(
            int id,
            string title,
            string description,
            string displayPrice,
            string displayDepartureTimes,
            string displayDuration,
            TourImageViewModel mainImageVm,
            string slug,
            string discountPercent,
            int languageId,
            int applicationID)
        {
            Id = id;
            DisplayDepartureTimes = displayDepartureTimes;
            MainImage = mainImageVm;
            Title = EnsureArg.IsNotNullOrEmpty(title, nameof(title));
            DisplayPrice = EnsureArg.IsNotNullOrEmpty(displayPrice, nameof(displayPrice));
            DisplayDuration = EnsureArg.IsNotNullOrEmpty(displayDuration, nameof(displayDuration));
            Description = EnsureArg.IsNotNullOrEmpty(description, nameof(description));
            Slug = EnsureArg.IsNotNullOrEmpty(slug, nameof(slug));
            DiscountPercent = discountPercent;
            LanguageId = languageId;
            ApplicationId = applicationID;
        }

        public int Id { get; }
        public string Title { get; }
        public string DisplayPrice { get; }
        public string DisplayDepartureTimes { get; }
        public string DisplayDuration { get; }
        public TourImageViewModel MainImage { get; }
        public string Description { get; }
        public string Slug { get; }
        public string DiscountPercent { get; set; }
        public int LanguageId { get; set; }
        public int ApplicationId { get; set; }
    }
}