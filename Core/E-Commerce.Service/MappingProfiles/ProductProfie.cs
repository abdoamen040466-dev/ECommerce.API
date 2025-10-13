namespace E_Commerce.Service.MappingProfiles;
public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(d => d.Brand,
            o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.Type,
            o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.PictureUrl,
            o => o.MapFrom<ProductPictureUrlResolver>());

        CreateMap<ProductBrand, BrandResponse>();
        CreateMap<ProductType, TypeResponse>();
    }
}
internal class ProductPictureUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductResponse, string>
{
    public string? Resolve(Product source, ProductResponse destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrWhiteSpace(source.PictureUrl))
            return null;
        return $"{configuration["BaseUrl"]}{source.PictureUrl}";
    }
}
