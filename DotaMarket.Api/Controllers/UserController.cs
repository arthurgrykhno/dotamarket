using DotaMarket.DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotaMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DotaMarketContext _context;

        public UserController(DotaMarketContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_context.Users);
        }
    }
}
