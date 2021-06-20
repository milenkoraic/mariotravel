using Microsoft.AspNetCore.Mvc;

namespace CableCarDubrovnik.Web.Controllers
{
    public class CookiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}