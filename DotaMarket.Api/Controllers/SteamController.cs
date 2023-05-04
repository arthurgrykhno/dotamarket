using AspNet.Security.OpenId.Steam;
using DotaMarket.Authorization;
using DotaMarket.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DotaMarket.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SteamController : ControllerBase
    {
        private readonly ISteamAuthenticationService _steamAuthService;
        private readonly IIdentityUserManager _identityUserManager;
        private readonly SteamOpenIdOptions _steamOpenIdOptions;

        public SteamController(
            ISteamAuthenticationService steamAuthService,
            IIdentityUserManager identityUserManager,
            IOptions<SteamOpenIdOptions> steamOpenIdOptions)
        {
            _steamAuthService = steamAuthService;
            _identityUserManager = identityUserManager;
            _steamOpenIdOptions = steamOpenIdOptions.Value;
        }

        [HttpGet("steam/login")]
        public IActionResult Login(string returnUrl = "/")
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action(nameof(Callback)) };
            return Challenge(properties, SteamAuthenticationDefaults.AuthenticationScheme);
        }

        [HttpGet("steam/external-login")]
        public async Task<IActionResult> Callback()
        {
            var externalLoginInfo = await _steamAuthService.GetExternalLoginInfoAsync(_steamOpenIdOptions.ReturnUrl);
            var user = await _identityUserManager.CreateOrUpdateUserAsync(externalLoginInfo.Principal, externalLoginInfo.AuthenticationScheme);
            if (user == null)
            {
                return BadRequest();
            }

            await _identityUserManager.SignInAsync(HttpContext, user);

            return Ok(new { message = "Successfully authenticated with Steam." });
        }
    }
}