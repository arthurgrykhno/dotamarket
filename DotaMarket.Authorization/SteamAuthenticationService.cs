using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using AspNet.Security.OpenId.Steam;

namespace DotaMarket.Authorization
{
    public class SteamAuthenticationService
    {
        public Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string returnUrl)
        {
            var properties = new AuthenticationProperties { RedirectUri = returnUrl };
            return Task.FromResult(new ExternalLoginInfo(
                new ClaimsPrincipal(new ClaimsIdentity()),
                SteamAuthenticationDefaults.AuthenticationScheme,
                "76561197960435530",
                "Steam user"
            ));
        }
    }
}
