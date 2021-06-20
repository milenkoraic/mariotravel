using Microsoft.AspNetCore.Mvc;

namespace MarioTravel.Admin.Infrastructure
{
    [Route("[controller]/[action]", Name = "[controller]_[action]")]
    public abstract class BaseController : Controller
    {
    }
}