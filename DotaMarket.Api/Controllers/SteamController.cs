using AspNet.Security.OpenId.Steam;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using DotaMarket.Authorization;
using Microsoft.Extensions.Options;

namespace DotaMarket.Api.Controllers
{
    public class SteamController : Controller
    {
        private readonly SteamAuthenticationService _steamAuthService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SteamOpenIdOptions _steamOpenIdOptions;

        public SteamController(
            SteamAuthenticationService steamAuthService,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<SteamOpenIdOptions> steamOpenIdOptions)
        {
            _steamAuthService = steamAuthService;
            _signInManager = signInManager;
            _userManager = userManager;
            _steamOpenIdOptions = steamOpenIdOptions.Value;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action(nameof(Callback)) };
            return Challenge(properties, SteamAuthenticationDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public async Task<IActionResult> Callback()
        {
            var result = await HttpContext.AuthenticateAsync(SteamAuthenticationDefaults.AuthenticationScheme);
            if (result.Succeeded)
            {
                var externalLoginInfo = await _steamAuthService.GetExternalLoginInfoAsync(_steamOpenIdOptions.ReturnUrl);
                var user = await _userManager.FindByLoginAsync(externalLoginInfo.LoginProvider, externalLoginInfo.ProviderKey);
                if (user == null)
                {
                    var email = $"{externalLoginInfo.Principal.FindFirstValue(ClaimTypes.NameIdentifier)}@example.com";
                    user = new IdentityUser { UserName = email, Email = email };
                    var createResult = await _userManager.CreateAsync(user);
                    if (!createResult.Succeeded)
                    {
                        return BadRequest();
                    }

                    var addLoginResult = await _userManager.AddLoginAsync(user, externalLoginInfo);
                    if (!addLoginResult.Succeeded)
                    {
                        return BadRequest();
                    }
                }

                await _signInManager.SignInAsync(user, isPersistent: false);
                return Redirect(_steamOpenIdOptions.ReturnUrl);
            }

            return BadRequest();
        }
    }
}
