using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PermissionsAttribute.Models;

namespace PermissionsAttribute
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .SeedDatabase()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public static class MigrationManager
    {
        public static IHost SeedDatabase(this IHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    SeedIdentityDb(userManager, roleManager).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            return webHost;
        }

        private static async Task SeedIdentityDb(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "admin@mail.com";
            var password = "Admin_1234";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                var adminRole = new IdentityRole("admin");
                await roleManager.CreateAsync(adminRole);
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                var userRole = new IdentityRole("user");
                await roleManager.CreateAsync(userRole);
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminEmail};
                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim("permission", Permission.GetById.ToString()),
                        new Claim("permission", Permission.GetAll.ToString()),
                        new Claim("permission", Permission.Create.ToString()),
                        new Claim("permission", Permission.Update.ToString()),
                        new Claim("permission", Permission.Delete.ToString())
                    };
                    await userManager.AddClaimsAsync(admin, claims);
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
