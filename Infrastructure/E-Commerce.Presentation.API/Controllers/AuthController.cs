using E_Commerc.ServiceAbstraction;
using E_Commerce.Shared.DataTransferObject.Auth;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.API.Controllers;
public class AuthController(IAuthService authService)
    : APIBaseController
{
    [HttpPost("Register")]
    public async Task<ActionResult<UserResponse>> Register(RegisterRequest request)
    {
        var result = await authService.RegisterAsync(request);
        return HandleResult(result);
    }
    [HttpPost("Login")]
    public async Task<ActionResult<UserResponse>> Login(LoginResponse request)
    {
        var result = await authService.LoginAsync(request);
        return HandleResult(result);

    }

    [HttpGet("CheckEmail")]
    public async Task<ActionResult<bool>> CheckEmail(string email)
    {
        return Ok(await authService.CheckEmail(email));
    }

}
