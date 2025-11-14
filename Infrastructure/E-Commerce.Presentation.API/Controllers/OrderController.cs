using E_Commerc.ServiceAbstraction;
using E_Commerce.Shared.DataTransferObject.UserOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce.Presentation.API.Controllers;
[Authorize]
public class OrderController(IOrderService orderService)
    : APIBaseController
{
    [HttpPost]
    public async Task<ActionResult<OrderResponse>> Create(OrderRequest request)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var result = await orderService.CreateAsync(request, email);
        return HandleResult(result);
    }
    [HttpGet]
    public async Task<ActionResult<List<OrderResponse>>> GetUserProduct()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var result = await orderService.GetUserOrderAsync(email);
        return HandleResult(result);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderResponse>> GetOrderById(Guid id)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var result = await orderService.GetOrderByIdAsync(id, email);
        return HandleResult(result);
    }
    [AllowAnonymous]
    [HttpGet("DeliveryMethod")]
    public async Task<ActionResult<DeliveryMethodDTO>> GetDeliveryMethods()
    {
        var result = await orderService.GetDeliveryMethodsAsync();
        return HandleResult(result);
    }
}
