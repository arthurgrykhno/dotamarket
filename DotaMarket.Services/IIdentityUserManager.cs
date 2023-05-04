using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DotaMarket.Services
{
    public interface IIdentityUserManager
    {
        Task<IdentityUser> FindByLoginAsync(string loginProvider, string providerKey);
        Task<IdentityResult> CreateAsync(IdentityUser user, string password);
        Task<IdentityResult> AddLoginAsync(IdentityUser user, UserLoginInfo loginInfo);
        Task<IdentityUser> CreateOrUpdateUserAsync(ClaimsPrincipal principal, string providerKey);
        Task SignInAsync(HttpContext context, IdentityUser user);
        Task<IList<Claim>> GetClaimsAsync(IdentityUser user);
    }
}