using E_Commerce.Shared.Basket;

namespace E_Commerc.ServiceAbstraction;
public interface IBasketService
{
    Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO basketDTO);
    Task<CustomerBasketDTO> GetByIdAsync(string id);
    Task DeleteAsync(string id);

}
