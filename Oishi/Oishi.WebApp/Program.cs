using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Oishi.Shared.Services;
using System.Configuration;

namespace Oishi.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var authenticationSettings = new GoogleOptions
            {
                ClientId = "196739486101-859k8js48gdsm94ps1amqvutafcebp6d.apps.googleusercontent.com",
                ClientSecret = "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",
                CallbackPath = "/signin-google",
            };

            // Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            }
            ).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, (options) =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
            }
            ).AddGoogle(GoogleDefaults.AuthenticationScheme, (options) =>
            {
                options.ClientId = authenticationSettings.ClientId;
                options.ClientSecret = authenticationSettings.ClientSecret;
                options.CallbackPath = authenticationSettings.CallbackPath;
            });


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}