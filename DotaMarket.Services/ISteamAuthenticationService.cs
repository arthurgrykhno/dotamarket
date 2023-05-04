using Microsoft.AspNetCore.Authentication;

namespace DotaMarket.Services
{
    public interface ISteamAuthenticationService
    {
        Task<AuthenticationTicket> GetExternalLoginInfoAsync(string returnUrl);
    }
}