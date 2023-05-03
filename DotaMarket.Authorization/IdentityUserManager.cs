using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DotaMarket.Authorization
{
    public class IdentityUserManager
    {
        private readonly UserManager<IdentityUser> _userManager;

        public IdentityUserManager(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityUser> FindByLoginAsync(string loginProvider, string providerKey)
        {
            var user = await _userManager.FindByLoginAsync(loginProvider, providerKey);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task<IdentityResult> CreateAsync(IdentityUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> AddLoginAsync(IdentityUser user, UserLoginInfo loginInfo)
        {
            return await _userManager.AddLoginAsync(user, loginInfo);
        }

        public async Task<IdentityUser> CreateOrUpdateUserAsync(ClaimsPrincipal principal, string providerKey)
        {
            var user = await _userManager.FindByLoginAsync(principal.FindFirstValue(ClaimTypes.NameIdentifier)!, providerKey);

            if (user == null)
            {
                user = new IdentityUser { UserName = principal.Identity!.Name };
                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    return null!;
                }
                await _userManager.AddLoginAsync(user, new UserLoginInfo(principal.FindFirstValue(ClaimTypes.NameIdentifier)!, providerKey, "Steam"));
            }
            else
            {
                user.UserName = principal.Identity!.Name;
                await _userManager.UpdateAsync(user);
            }
            return user;
        }

        public async Task SignInAsync(HttpContext context, IdentityUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // add additional claims from the user object if needed
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName!));

            var principal = new ClaimsPrincipal(identity);
            await context.SignInAsync(principal);
        }
        public async Task<IList<Claim>> GetClaimsAsync(IdentityUser user)
        {
            return await _userManager.GetClaimsAsync(user);
        }
    }
}
