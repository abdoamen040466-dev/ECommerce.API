namespace E_Commerce.Service.DependencyInjection;
public static class ApplicationServiceExtentions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection service)
    {
        service.AddScoped<IProductService, ProductService>();
        service.AddAutoMapper(Assembly.GetExecutingAssembly());
        return service;
    }

}
