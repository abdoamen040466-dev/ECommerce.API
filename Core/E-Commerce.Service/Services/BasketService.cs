using E_Commerce.Domain.Entities.Basket;
using E_Commerce.Shared.Basket;

namespace E_Commerce.Service.Services;
public class BasketService(IBasketRepository basketRepository, IMapper mapper) : IBasketService
{
    public async Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO basketDTO)
    {
        var basket = mapper.Map<CustomerBasket>(basketDTO);
        var updatedBasket = await basketRepository.CreateOrUpdateAsync(basket);
        return mapper.Map<CustomerBasketDTO>(updatedBasket);
    }

    public async Task DeleteAsync(string id)
    {
        await basketRepository.DeleteAsync(id);
    }

    public async Task<CustomerBasketDTO> GetByIdAsync(string id)
    {
        var basket = await basketRepository.GetAsync(id);
        return mapper.Map<CustomerBasketDTO>(basket);
    }
}
