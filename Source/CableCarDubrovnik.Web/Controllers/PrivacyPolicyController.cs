using Microsoft.AspNetCore.Mvc;

namespace CableCarDubrovnik.Web.Controllers
{
    public class PrivacyPolicyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}