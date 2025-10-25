using StackExchange.Redis;

namespace E_Commerce.Presistense.DependencyInjection;
public static class PresistenceServiceExtentions
{
    public static IServiceCollection AddPresistenceServices(this IServiceCollection service
        , IConfiguration configuration)
    {

        service.AddSingleton<IConnectionMultiplexer>(cfg =>
        {
            return ConnectionMultiplexer.Connect(configuration
                   .GetConnectionString("RedisConnection")!);
        });
        service.AddDbContext<ApplicationDbContext>(options =>
        {
            var connection = configuration.GetConnectionString("SQLConnection");

            options.UseSqlServer(connection);
        });
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        service.AddScoped<IDbInitializer, DbInitializer>();
        return service;
    }
}
