using E_Commerce.Domain.Entities.Auth;
using E_Commerce.Presistense.AuthContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace E_Commerce.Presistense.DbInitializers;
internal class DbInitializer(StoreDbContext dbContext,
    AuthDbContext authDbContext,
    RoleManager<IdentityRole> roleManager,
    UserManager<ApplicationUser> userManager,
    ILogger<DbInitializer> logger)
    : IDbInitializer
{
    public async Task InitializeAsync()
    {
        // create DB
        // update DB
        if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
            await dbContext.Database.MigrateAsync();
        if (!dbContext.ProductBrands.Any())
        {
            // Read As Json
            var BrandsData = await File.ReadAllTextAsync(@"..\Infrastructure\E-Commerce.Presistense\Context\DataSeed\brands.json");
            // Deserialize
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData, options);
            if (brands != null && brands.Any())
            {
                dbContext.ProductBrands.AddRange(brands);
            }
            // Save To DB
            await dbContext.SaveChangesAsync();
        }
        if (!dbContext.ProductTypes.Any())
        {
            var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\E-Commerce.Presistense\Context\DataSeed\types.json");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var types = JsonSerializer.Deserialize<List<ProductType>>(typesData, options);
            if (types != null && types.Any())
            {
                dbContext.ProductTypes.AddRange(types);
            }
            // Save To DB
            await dbContext.SaveChangesAsync();
        }
        if (!dbContext.Products.Any())
        {
            var ProductsData = await File.ReadAllTextAsync(@"..\Infrastructure\E-Commerce.Presistense\Context\DataSeed\products.json");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData, options);
            if (Products != null && Products.Any())
            {
                dbContext.Products.AddRange(Products);
            }
            // Save To DB
            await dbContext.SaveChangesAsync();
        }

    }

    public async Task InitializeAuthDbAsync()
    {
        await authDbContext.Database.MigrateAsync();

        if (!roleManager.Roles.Any())
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        }
        if (!userManager.Users.Any())
        {
            var SuperAdminUser = new ApplicationUser
            {
                DisplayName = "Super Admin",
                Email = "SuperAdmin@gmail.com",
                UserName = "SuperAdmin",
                PhoneNumber = "01000000000",
            };
            var adminUser = new ApplicationUser
            {
                DisplayName = "Admin",
                Email = "Admin@gmail.com",
                UserName = "Admin",
                PhoneNumber = "01123456789",
            };
            await userManager.CreateAsync(SuperAdminUser, "Passw0rd");
            await userManager.CreateAsync(adminUser, "Passw0rd");

            await userManager.AddToRoleAsync(SuperAdminUser, "SuperAdmin");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }

}
