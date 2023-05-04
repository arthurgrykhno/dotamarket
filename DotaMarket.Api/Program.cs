using DotaMarket.DataLayer;
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

            // Configure Steam and Register the authentication handler for "Steam" scheme
            builder.Services.ConfigureIdentity();

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
            app.UseAuthorization();

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

            app.MapControllers();

            app.Run();
        }
    }
}