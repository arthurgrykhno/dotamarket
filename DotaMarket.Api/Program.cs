using DotaMarket.Authorization;
using DotaMarket.DataLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotaMarket.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Configure Steam 
            builder.Services.AddScoped<SteamAuthenticationService>();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
             .AddEntityFrameworkStores<DotaMarketContext>()
             .AddDefaultTokenProviders()
             .AddSignInManager<SignInManager<IdentityUser>>();

            builder.Services.AddScoped<IdentityUserManager>();

            // Register the authentication handler for "Steam" scheme
            ConfigureIdentity(builder.Services);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddDbContext<DotaMarketContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "steam-login",
                    pattern: "steam/login",
                    defaults: new { controller = "Steam", action = "Login" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        public static void ConfigureIdentity(IServiceCollection services)
        {
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