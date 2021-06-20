using CableCarDubrovnik.Web.Models.Tour;
using System.Collections.Generic;

namespace CableCarDubrovnik.Web.Models.Home
{
    public class TourCollectionByTypeViewModel
    {
        public TourCollectionByTypeViewModel(string type, IEnumerable<TourPreviewViewModel> tours)
        {
            Type = type ?? throw new System.ArgumentNullException(nameof(type));
            Tours = tours;
        }

        public string Type { get; }
        public IEnumerable<TourPreviewViewModel> Tours { get; }
    }
}