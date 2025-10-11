namespace E_Commerce.Presistense.DependencyInjection;
public static class PresistenceServiceExtentions
{
    public static IServiceCollection AddPresistenceServices(this IServiceCollection service
        , IConfiguration configuration)
    {
        service.AddDbContext<ApplicationDbContext>(options =>
        {
            var connection = configuration.GetConnectionString("SQLConnection");

            options.UseSqlServer(connection);
        });
        return service;
    }
}
