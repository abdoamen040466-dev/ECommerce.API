using E_Commerc.ServiceAbstraction;
using E_Commerce.Shared.Basket;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.API.Controllers;
public class BasketsController(IBasketService basketService) : APIBaseController
{
    [HttpPost]
    public async Task<ActionResult<CustomerBasketDTO>> update(CustomerBasketDTO basketDTO)
    {
        return Ok(await basketService.CreateOrUpdateAsync(basketDTO));
    }
    [HttpGet]
    public async Task<ActionResult<CustomerBasketDTO>> Get(string id)
    {
        return Ok(await basketService.GetByIdAsync(id));
    }
    // Post baseUrl/api/Baskets?id=value
    [HttpDelete]
    public async Task<ActionResult> Delete(string id)
    {
        await basketService.DeleteAsync(id);
        return NoContent();
    }

}
