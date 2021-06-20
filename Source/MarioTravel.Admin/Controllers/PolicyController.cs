using MarioTravel.Admin.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarioTravel.Admin.Controllers
{
    public class PolicyController : BaseController
    {
        private readonly ILogger<PolicyController> _logger;

        public PolicyController(
            ILogger<PolicyController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cookies()
        {
            return View();
        }
    }
}