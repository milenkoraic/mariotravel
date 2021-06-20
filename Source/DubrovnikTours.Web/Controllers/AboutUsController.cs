using Microsoft.AspNetCore.Mvc;

namespace DubrovnikTours.Web.Controllers
{
    public class AboutUsController : Controller
    {
        public ViewResult About()
        {
            return View();
        }
    }
}