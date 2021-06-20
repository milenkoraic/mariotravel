using MarioTravel.Admin.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarioTravel.Admin.Controllers
{
    public class SupportController : BaseController
    {
        private readonly ILogger<SupportController> _logger;

        public SupportController(
            ILogger<SupportController> logger)
        {
            _logger = logger;
        }

        public IActionResult DeveloperInfo()
        {
            return View();
        }
    }
}