using Microsoft.AspNetCore.Mvc;

namespace DubrovnikTours.Web.Controllers
{
    public class CookiesController : Controller
    {
        public IActionResult CookiesList()
        {
            return View();
        }
    }
}