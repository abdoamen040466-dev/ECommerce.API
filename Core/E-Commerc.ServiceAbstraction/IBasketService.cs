using E_Commerc.ServiceAbstraction.Common;
using E_Commerce.Shared.Basket;

namespace E_Commerc.ServiceAbstraction;
public interface IBasketService
{
    Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO basketDTO);
    Task<Result<CustomerBasketDTO>> GetByIdAsync(string id);
    Task DeleteAsync(string id);

}
