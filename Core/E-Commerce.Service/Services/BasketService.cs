using E_Commerc.ServiceAbstraction.Common;
using E_Commerce.Domain.Entities.Basket;
using E_Commerce.Service.Exceptions;
using E_Commerce.Shared.DataTransferObject.Basket;

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

    public async Task<Result<CustomerBasketDTO>> GetByIdAsync(string id)
    {
        var basket = await basketRepository.GetAsync(id);

        if (basket == null)
            return Error.NotFound();

        return mapper.Map<CustomerBasketDTO>(basket);
    }
}
