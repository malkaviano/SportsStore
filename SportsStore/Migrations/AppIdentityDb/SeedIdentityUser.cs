using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Migrations.AppIdentityDb
{
    public class SeedIdentityUser
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        public static async void EnsurePopulated(UserManager<IdentityUser> userManager)
        {
            var user = await userManager.FindByIdAsync(adminUser);

            if (user == null)
            {
                user = new IdentityUser(adminUser);
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
