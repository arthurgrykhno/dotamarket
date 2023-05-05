using DotaMarket.Authorization;
using DotaMarket.Contracts;
using DotaMarket.DataLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace DotaMarket.Api
{
    public static class IdentityExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
             .AddEntityFrameworkStores<DotaMarketContext>()
             .AddDefaultTokenProviders()
             .AddSignInManager<SignInManager<IdentityUser>>();

            services.AddScoped<ISteamAuthenticationService, SteamAuthenticationService>();

            services.AddScoped<IIdentityUserManager, IdentityUserManager>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
               .AddCookie()
               .AddSteam(options =>
               {
                   options.ApplicationKey = "C806017BEFEACB91164AB95E1704912A";
               });
        }
    }
}