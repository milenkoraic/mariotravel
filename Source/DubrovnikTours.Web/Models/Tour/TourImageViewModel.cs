using EnsureThat;

namespace DubrovnikTours.Web.Models.Tour
{
    public class TourImageViewModel
    {
        public TourImageViewModel(string url, string altDescription)
        {
            Url = EnsureArg.IsNotNullOrEmpty(url, nameof(url));
            AltDescription = altDescription;
        }

        public string Url { get; }
        public string AltDescription { get; }
    }
}