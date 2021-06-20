using Microsoft.AspNetCore.Mvc;

namespace CableCarDubrovnik.Web.App.Infrastructure
{
    [Route("[controller]/[action]", Name = "[controller]_[action]")]
    public abstract class BaseController : Controller
    {
    }
}
