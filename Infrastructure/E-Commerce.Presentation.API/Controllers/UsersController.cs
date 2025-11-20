using E_Commerc.ServiceAbstraction;
using E_Commerce.Shared.DataTransferObject.Auth;
using E_Commerce.Shared.DataTransferObject.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace E_Commerce.Presentation.API.Controllers;
[Authorize]
public class UsersController(IUserService userService)
    : APIBaseController
{
    [HttpGet]
    public async Task<ActionResult<UserResponse>> GetUser()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);

        var result = await userService.GetByEmailAsync(email!);
        return HandleResult(result);
    }
    [HttpGet("Address")]
    public async Task<ActionResult<AddressDTO>> GetAddress()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);

        var result = await userService.GetAddessAsync(email!);
        return HandleResult(result);
    }
    [HttpPut("Address")]
    public async Task<ActionResult<AddressDTO>> UpdateAddress(AddressDTO address)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);

        var result = await userService.UpdateAddressAsync(email!, address);
        return HandleResult(result);
    }

}
