using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ListaTasks.Data
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAdminUser(UserManager<IdentityUser> userManager)
        {
            var admin = await userManager.FindByNameAsync("admin");
            if (admin == null)
            {
                admin = new IdentityUser { UserName = "Admin", Email = "Admin@ICAD!" };

                // Desabilitar Validação para seeding
                userManager.Options.Password.RequireDigit = false;
                userManager.Options.Password.RequireLowercase = false;
                userManager.Options.Password.RequireUppercase = false;
                userManager.Options.Password.RequireNonAlphanumeric = false;

                var result = await userManager.CreateAsync(admin, "Admin@ICAD!");
                if (!result.Succeeded)
                {
                    // Log de todos os erros caso necessário
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new System.Exception($"Failed to create admin user: {errors}");
                }
            }
        }
    }
}