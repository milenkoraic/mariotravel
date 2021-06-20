using MarioTravel.Admin.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarioTravel.Admin.Controllers
{
    public class LocationsController : BaseController
    {
        private readonly ILogger<LocationsController> _logger;

        public LocationsController(
            ILogger<LocationsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Maps()
        {
            return View();
        }
    }
}