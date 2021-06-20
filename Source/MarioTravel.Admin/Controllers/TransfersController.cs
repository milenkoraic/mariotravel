using MarioTravel.Admin.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarioTravel.Admin.Controllers
{
    [Authorize]
    public class TransfersController : BaseController
    {
        private readonly ILogger<TransfersController> _logger;

        public TransfersController(
            ILogger<TransfersController> logger)
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