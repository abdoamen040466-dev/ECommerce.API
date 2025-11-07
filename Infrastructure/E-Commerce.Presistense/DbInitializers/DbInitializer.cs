namespace E_Commerce.Presistense.DbInitializers;
internal class DbInitializer(StoreDbContext dbContext) : IDbInitializer
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
}
