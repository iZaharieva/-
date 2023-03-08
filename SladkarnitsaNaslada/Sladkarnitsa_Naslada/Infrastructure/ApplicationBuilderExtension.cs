using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Sladkarnitsa_Naslada.Data;
using Sladkarnitsa_Naslada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sladkarnitsa_Naslada.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            var dataCategory = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataCategory);
            var dataMaker = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedMakers(dataMaker);

            return app;
        }
        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Administrator", "Client" };
            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "admin";
                user.LastName = "admin";
                user.PhoneNumber = "0899999999";
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                var result = await userManager.CreateAsync(user, "1234567");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
        private static void SeedCategories(ApplicationDbContext dataCategory)
        {
            if (dataCategory.Categories.Any())
            {
                return;
            }
            dataCategory.Categories.AddRange(new[]
            {
                new Category {CategoryName="Party Cakes"},
                new Category {CategoryName="Wedding Cakes"},
                new Category {CategoryName="Classic Cakes"},
                new Category {CategoryName="Sugar Sweets"},
                new Category {CategoryName="Child Cakes"}
            });
            dataCategory.SaveChanges();
        }
        private static void SeedMakers(ApplicationDbContext dataMaker)
        {
            if (dataMaker.Makers.Any())
            {
                return;
            }
            dataMaker.Makers.AddRange(new[]
            {
                new Maker {MakerName="Sweet Shop"},
                new Maker {MakerName="Naslada"}
            });
            dataMaker.SaveChanges();
        }
    }
}

