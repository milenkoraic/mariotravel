using MarioTravel.Admin.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarioTravel.Admin.Controllers
{
    [Authorize]
    public class ToursController : BaseController
    {
        private readonly ILogger<ToursController> _logger;

        [TempData]
        public string StatusMessage { get; set; }

        public ToursController(
            ILogger<ToursController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bookings()
        {
            return View();
        }

        public IActionResult Statistics()
        {
            return View();
        }
    }
}