using E_Commerc.ServiceAbstraction.Common;
using E_Commerce.Domain.Entities.Auth;
using E_Commerce.Service.Contracts;
using E_Commerce.Shared.DataTransferObject.Auth;
using E_Commerce.Shared.DataTransferObject.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Service.Services;
public class UserService(
    UserManager<ApplicationUser> userManager,
    ITokenService tokenService,
    IMapper mapper)
    : IUserService
{
    public async Task<Result<UserResponse>> GetByEmailAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
            return Error.NotFound("User Not Found", $"User with email {email} was not found");

        var roles = await userManager.GetRolesAsync(user);
        return new UserResponse(user.Email, user.DisplayName, tokenService.GetToken(user, roles));
    }
    public async Task<Result<AddressDTO>> GetAddessAsync(string email)
    {
        var user = await userManager.Users
            .Include(u => u.Address)
            .FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
            return Error.NotFound("User Not Found", $"User with email {email} was not found");

        if (user.Address == null)
            return Error.NotFound("Addresss Not Found", $"User with email {email} doesn't have Address");
        return mapper.Map<AddressDTO>(user.Address);
    }
    public async Task<Result<AddressDTO>> UpdateAddressAsync(string email, AddressDTO address)
    {
        var user = await userManager.Users
            .Include(u => u.Address)
            .FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
            return Error.NotFound("User Not Found", $"User with email {email} was not found");
        if (user.Address is not null)
        {
            user.Address.FirstName = address.FirstName;
            user.Address.LastName = address.LastName;
            user.Address.Street = address.Street;
            user.Address.City = address.City;
            user.Address.Country = address.Country;
        }
        else
        {
            user.Address = mapper.Map<Address>(address);
        }

        await userManager.UpdateAsync(user);

        return mapper.Map<AddressDTO>(user.Address);
    }

}
