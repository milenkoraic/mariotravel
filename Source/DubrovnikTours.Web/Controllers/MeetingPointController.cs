using DubrovnikTours.Web.Models;
using EnsureThat;
using MarioTravel.Core.Configuration.Api.Keys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DubrovnikTours.Web.Controllers
{
    public class MeetingPointController : Controller
    {
        private readonly GoogleMaps googleMaps;

        public MeetingPointController(IOptions<GoogleMaps> gmapsOptsAccessor)
        {
            EnsureArg.IsNotNull(gmapsOptsAccessor, nameof(gmapsOptsAccessor));

            googleMaps = EnsureArg.IsNotNull(gmapsOptsAccessor.Value, nameof(googleMaps));
            EnsureArg.IsNotNullOrEmpty(googleMaps.ApiKey, nameof(googleMaps.ApiKey));
        }

        public ViewResult MeetingInfo()
        {
            var vm = new MeetingPointViewModel(googleMaps.ApiKey);
            return View(vm);
        }
    }
}