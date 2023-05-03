using AspNet.Security.OpenId.Steam;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace DotaMarket.Authorization
{
    public class SteamAuthenticationService
    {
        public Task<AuthenticationTicket> GetExternalLoginInfoAsync(string returnUrl)
        {
            var properties = new AuthenticationProperties { RedirectUri = returnUrl };
            var identity = new ClaimsIdentity(new List<Claim>(), SteamAuthenticationDefaults.AuthenticationScheme, ClaimTypes.NameIdentifier, null);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, properties, SteamAuthenticationDefaults.AuthenticationScheme);
            return Task.FromResult(ticket);
        }
    }
}
