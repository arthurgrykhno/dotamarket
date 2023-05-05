using Microsoft.AspNetCore.Authentication;

namespace DotaMarket.Contracts
{
    public interface ISteamAuthenticationService
    {
        Task<AuthenticationTicket> GetExternalLoginInfoAsync(string returnUrl);
    }
}
