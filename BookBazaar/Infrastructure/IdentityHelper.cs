
using Microsoft.AspNetCore.Identity;
using Microsoft.DotNet.Scaffolding.Shared;
using System.Data;

namespace BookBazaar.Infrastructure
{
    /// <summary>
    /// this class is used to create roles and default user
    /// </summary>
    public class IdentityHelper : IIdentityHelper
    {
        public const string Administrator = "Administrator";
        public const string User = "User";

        /// <summary>
        /// this method is used to create roles
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static async Task CreateDefaultUser(IServiceProvider provider, string roles)
        {
            UserManager<IdentityUser> userManager = provider.GetRequiredService<UserManager<IdentityUser>>();

            if (userManager.Users.Count() == 0)
            {
                IdentityUser defaultUser = new IdentityUser
                {
                    Email = "Admin@gmail.com",
                    EmailConfirmed = true,
                    UserName = "Admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                };

                await userManager.CreateAsync(defaultUser, "Admin@123");

                await userManager.AddToRoleAsync(defaultUser, Administrator);
            }
        }

        /// <summary>
        /// this method is used to create roles
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            // Create the roles if they don't exist
            foreach (string role in roles)
            {
                bool roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}

