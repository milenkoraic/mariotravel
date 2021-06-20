using MarioTravel.Admin.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarioTravel.Admin.Controllers
{
    [Authorize]
    public class AssociatesController : BaseController
    {
        private readonly ILogger<AssociatesController> _logger;

        public AssociatesController(
            ILogger<AssociatesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Links()
        {
            return View();
        }
    }
}