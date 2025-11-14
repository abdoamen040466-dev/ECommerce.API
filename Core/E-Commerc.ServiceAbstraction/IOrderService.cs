using E_Commerc.ServiceAbstraction.Common;
using E_Commerce.Shared.DataTransferObject.UserOrder;

namespace E_Commerc.ServiceAbstraction;
public interface IOrderService
{
    Task<Result<OrderResponse>> CreateAsync(OrderRequest request, string email);
}
