using E_Commerce.Shared.DataTransferObject.Users;

namespace E_Commerce.Shared.DataTransferObject.UserOrder;
public record OrderRequest(AddressDTO Address, string BasketId, int DeliveryMethodId);
