using E_Commerc.ServiceAbstraction.Common;
using E_Commerce.Shared.DataTransferObject.Auth;

namespace E_Commerc.ServiceAbstraction;
public interface IAuthService
{
    Task<Result<UserResponse>> LoginAsync(LoginResponse Request);
    Task<Result<UserResponse>> RegisterAsync(RegisterRequest Request);
    Task<bool> CheckEmail(string email);
}
