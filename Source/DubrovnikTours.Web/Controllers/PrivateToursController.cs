using DubrovnikTours.Web.Views.Mappers;
using MarioTravel.Core.BLL.Models.Tour;
using MarioTravel.Core.BLL.Services.Tour.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DubrovnikTours.Web.Controllers
{
    public class PrivateToursController : Controller
    {
        private readonly TourService tourService;
        private readonly TourMapper tourMapper;

        public PrivateToursController(
            TourService tourService, 
            TourMapper tourMapper)
        {
            this.tourService = tourService ?? throw new System.ArgumentNullException(nameof(tourService));
            this.tourMapper = tourMapper ?? throw new System.ArgumentNullException(nameof(tourMapper));
        }

        public async Task<ViewResult> PrivateToursList()
        {
            var types = await tourService.GetTourTypesAsync();
            var scheduledTourType = types.FirstOrDefault(t => t.Name.ToLower() == "private");

            var filter = new GetToursPreviewFilter(scheduledTourType.Id);

            var tours = await tourService.GetTourPreviewsAsync(filter);

            var tourVms = tourMapper.TourPreviewViewModel(tours);

            return View(tourVms);
        }
    }
}