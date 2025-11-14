using E_Commerc.ServiceAbstraction.Common;
using E_Commerce.Domain.Entities.Auth;
using E_Commerce.Service.Contracts;
using E_Commerce.Shared.DataTransferObject.Auth;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Service.Services;
internal class AuthService(UserManager<ApplicationUser> userManager,
    ITokenService tokenService) : IAuthService
{
    public async Task<bool> CheckEmail(string email)
        => await userManager.FindByEmailAsync(email) != null;
    public async Task<Result<UserResponse>> LoginAsync(LoginResponse Request)
    {
        var user = await userManager.FindByEmailAsync(Request.Email);

        if (user == null)
            return Error.Unauthorized(description: "Invalid Email Or Password");

        var result = await userManager.CheckPasswordAsync(user, Request.Password);
        if (!result)
            return Error.Unauthorized(description: "Invalid Email Or Password");

        var roles = await userManager.GetRolesAsync(user);

        var token = tokenService.GetToken(user, roles);
        return new UserResponse(user.Email, user.DisplayName, token);
    }

    public async Task<Result<UserResponse>> RegisterAsync(RegisterRequest registerRequest)
    {
        var user = new ApplicationUser
        {
            Email = registerRequest.Email,
            DisplayName = registerRequest.DisplayName,
            UserName = registerRequest.UserName,
            PhoneNumber = registerRequest.PhoneNumber
        };

        // Password Policy
        // UserName , Email
        var result = await userManager.CreateAsync(user, registerRequest.Password);

        if (!result.Succeeded)
            return result.Errors.Select(x => Error.Validation(x.Code, x.Description))
                .ToList();

        var token = tokenService.GetToken(user, []);

        return new UserResponse(user.Email, user.DisplayName, token);


    }

}
