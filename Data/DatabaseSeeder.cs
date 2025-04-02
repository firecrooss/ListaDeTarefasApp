// Data/DatabaseSeeder.cs
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ListaTasks.Data
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAdminUser(UserManager<IdentityUser> userManager)
        {
            // Check if admin already exists
            var admin = await userManager.FindByNameAsync("admin");
            if (admin == null)
            {
                admin = new IdentityUser { UserName = "admin", Email = "admin@example.com" };
                var result = await userManager.CreateAsync(admin, "Admin@AKAD!");
                if (!result.Succeeded)
                {
                    throw new System.Exception("Failed to create admin user");
                }
            }
        }
    }
}