using E_Commerc.ServiceAbstraction;
using E_Commerce.Domain.Entities.Auth;
using E_Commerce.Presistense.AuthContext;
using E_Commerce.Presistense.Service;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;

namespace E_Commerce.Presistense.DependencyInjection;
public static class PresistenceServiceExtentions
{
    public static IServiceCollection AddPresistenceServices(this IServiceCollection service
        , IConfiguration configuration)
    {
        service.AddDbContext<AuthDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("AuthConnection"));
        });


        service.AddScoped<ICashService, CashService>();
        service.AddScoped<IBasketRepository, BasketRepository>();
        service.AddSingleton<IConnectionMultiplexer>(cfg =>
        {
            return ConnectionMultiplexer.Connect(configuration
                   .GetConnectionString("RedisConnection")!);
        });
        service.AddDbContext<StoreDbContext>(options =>
        {
            var connection = configuration.GetConnectionString("SQLConnection");

            options.UseSqlServer(connection);
        });
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        service.AddScoped<IDbInitializer, DbInitializer>();

        ConfigureIdentity(service);

        return service;
    }


    private static void ConfigureIdentity(IServiceCollection service)
    {
        service.AddIdentityCore<ApplicationUser>(cfg =>
        {
            cfg.Password.RequiredLength = 8;
            cfg.Password.RequireNonAlphanumeric = false;
            cfg.Password.RequireUppercase = false;
            cfg.Password.RequireLowercase = false;
            cfg.Password.RequireDigit = false;
            cfg.User.RequireUniqueEmail = true;
        })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AuthDbContext>();
    }

}
