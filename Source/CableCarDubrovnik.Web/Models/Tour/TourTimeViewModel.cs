using EnsureThat;

namespace CableCarDubrovnik.Web.Models.Tour
{
    public class TourTimeViewModel
    {
        public TourTimeViewModel(string startAt)
        {
            StartAt = EnsureArg.IsNotNullOrEmpty(startAt, nameof(startAt));
        }

        public string StartAt { get; }
    }
}