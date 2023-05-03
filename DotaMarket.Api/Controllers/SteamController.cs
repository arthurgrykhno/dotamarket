using AspNet.Security.OpenId.Steam;
using DotaMarket.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DotaMarket.Api.Controllers
{
    [Produces("application/json")]
    public class SteamController : Controller
    {
        private readonly SteamAuthenticationService _steamAuthService;
        private readonly IdentityUserManager _identityUserManager;
        private readonly SteamOpenIdOptions _steamOpenIdOptions;

        public SteamController(
            SteamAuthenticationService steamAuthService,
            IdentityUserManager identityUserManager,
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

            return Redirect(_steamOpenIdOptions.ReturnUrl);
        }
    }
}