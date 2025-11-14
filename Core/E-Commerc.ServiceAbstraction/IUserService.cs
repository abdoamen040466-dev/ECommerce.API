using E_Commerc.ServiceAbstraction.Common;
using E_Commerce.Shared.DataTransferObject.Auth;
using E_Commerce.Shared.DataTransferObject.Users;

namespace E_Commerc.ServiceAbstraction;
public interface IUserService
{
    Task<Result<UserResponse>> GetByEmailAsync(string email);
    Task<Result<AddressDTO>> GetAddessAsync(string email);
    Task<Result<AddressDTO>> UpdateAddressAsync(string email, AddressDTO address);

}
