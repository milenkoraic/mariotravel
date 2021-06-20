using Microsoft.AspNetCore.Mvc;

namespace DubrovnikTours.Web.Controllers
{
    public class PolicyController : Controller
    {
        public IActionResult Privacy()
        {
            return View();
        }
    }
}