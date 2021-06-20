using DubrovnikTours.Web.Views.Mappers;
using MarioTravel.Core.BLL.Services.Tour.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DubrovnikTours.Web.Controllers
{
    public class TourController : Controller
    {
        private readonly TourService tourService;
        private readonly TourMapper tourMapper;

        public TourController(TourService tourService, TourMapper tourMapper)
        {
            this.tourService = tourService ?? throw new ArgumentNullException(nameof(tourService));
            this.tourMapper = tourMapper ?? throw new ArgumentNullException(nameof(tourMapper));
        }

        public async Task<IActionResult> TourBooking(int id, string slug)
        {
            var tour = await tourService.GetTourAsync(id);

            if (tour == null)
            {
                return RedirectToActionPermanent("Index", "Home");
            }

            if (tour.Slug != slug)
            {
                return RedirectToAction("Index", "Tour", new { tour.Id, tour.Slug });
            }

            var tourModel = tourMapper.TourViewModel(tour);
            return View(tourModel);
        }
    }
}