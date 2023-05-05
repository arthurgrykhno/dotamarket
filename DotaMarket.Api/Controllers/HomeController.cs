using Microsoft.AspNetCore.Mvc;

namespace DotaMarket.Api.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
