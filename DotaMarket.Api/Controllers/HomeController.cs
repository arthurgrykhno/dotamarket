using Microsoft.AspNetCore.Mvc;

namespace DotaMarket.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
