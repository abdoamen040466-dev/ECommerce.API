using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Shared.DataTransferObject.UserOrder;
using E_Commerce.Shared.DataTransferObject.Users;

namespace E_Commerce.Service.MappingProfiles;
internal class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderResponse>()
            .ForMember(d => d.DeliveryMethod,
            o => o.MapFrom(s => s.DeliveryMethod.ShortName))
            .ForMember(d => d.DeliveryMethodCost,
            o => o.MapFrom(s => s.DeliveryMethod.Price))
            .ForMember(d => d.Total,
            o => o.MapFrom(s => s.DeliveryMethod.Price + s.SubTotal));

        CreateMap<OrderAddress, AddressDTO>()
            .ReverseMap();

        CreateMap<OrderItem, OrderItemDTO>()
            .ForMember(d => d.ProductId,
            o => o.MapFrom(s => s.Product.ProductId))
            .ForMember(d => d.Name,
            o => o.MapFrom(s => s.Product.Name))
            .ForMember(d => d.PictureUrl,
            o => o.MapFrom<OrderPictureUrlResolver>()); 
    }

}


internal class OrderPictureUrlResolver(IConfiguration configuration) : IValueResolver<OrderItem, OrderItemDTO, string>
{

    public string? Resolve(OrderItem source, OrderItemDTO destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrWhiteSpace(source.Product.PictureUrl))
            return null;
        return $"{configuration["BaseUrl"]}{source.Product.PictureUrl}";
    }
}
