using DubrovnikTours.Web.App.Infrastructure.TextModification;
using DubrovnikTours.Web.Models.Home;
using DubrovnikTours.Web.Views.Mappers;
using EnsureThat;
using MarioTravel.Core.BLL.Models.Tour;
using MarioTravel.Core.BLL.Services.Tour.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubrovnikTours.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly RequestLocalizationOptions localizationOptions;
        private readonly TourService tourService;
        private readonly TourMapper tourMapper;

        public HomeController(
            IOptions<RequestLocalizationOptions> localizationOptionsAccessor,
            TourService tourService, 
            TourMapper tourMapper)
        {
            EnsureArg.IsNotNull(localizationOptionsAccessor, nameof(localizationOptionsAccessor));
            localizationOptions = EnsureArg.IsNotNull(localizationOptionsAccessor.Value, nameof(localizationOptionsAccessor.Value));
            this.tourService = EnsureArg.IsNotNull(tourService, (nameof(tourService)));
            this.tourMapper = EnsureArg.IsNotNull(tourMapper, (nameof(tourMapper)));
        }

        public async Task<IActionResult> Index()
        {
            var tourTypes = await tourService.GetTourTypesAsync();

            var vm = new List<TourCollectionByTypeViewModel>();

            foreach (var type in tourTypes)
            {
                var filter = new GetToursPreviewFilter(typeId: type.Id);
                var tours = await tourService.GetTourPreviewsAsync(filter).ConfigureAwait(false);

                var tourVms = tourMapper.TourPreviewViewModel(tours);
                vm.Add(new TourCollectionByTypeViewModel(type.Name.UppercaseFirstLetter(), tourVms));
            }

            return View(vm.ToArray());
        }

        private string _currentLanguage;

        private string CurrentLanguage
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentLanguage))
                    return _currentLanguage;

                if (string.IsNullOrEmpty(_currentLanguage))
                {
                    var feature = HttpContext.Features.Get<IRequestCultureFeature>();
                    _currentLanguage = feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLower();
                }

                return _currentLanguage;
            }
        }

        public ActionResult RedirectToDefaultCulture()
        {
            var culture = CurrentLanguage;
            if (culture != "en")
                culture = "en";
            return RedirectToAction("Index", new { culture });
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string language)
        {
            var uiCulture = "en-US";

            if (localizationOptions.SupportedUICultures.Any(c => c.Name == language))
            {
                uiCulture = language;
            }

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en-US", uiCulture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            return RedirectToAction("Index");
        }
    }
}