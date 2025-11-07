using E_Commerc.ServiceAbstraction;
using E_Commerce.Presentation.API.Attributes;
using E_Commerce.Shared.DataTransferObject;
using E_Commerce.Shared.DataTransferObject.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.API.Controllers;
public class ProductsController(IProductService service) : APIBaseController
{
    [RedisCash]
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<ProductResponse>>> GetProducts([FromQuery] ProductQueryParameters parameters, CancellationToken cancellationToken = default)
    {
        var response = await service.GetProductsAsync(parameters, cancellationToken);
        return Ok(response);
    }
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> Get(int id, CancellationToken cancellationToken = default)
    {
        var response = await service.GetByIdAsync(id, cancellationToken);
        return HandleResult(response);
    }
    [HttpGet("Brands")]
    public async Task<ActionResult<IEnumerable<BrandResponse>>> GetBrands(CancellationToken cancellationToken = default)
    {
        var response = await service.GetBrandsAsync(cancellationToken);
        return Ok(response);
    }
    [HttpGet("Types")]
    public async Task<ActionResult<IEnumerable<TypeResponse>>> GetTypes(CancellationToken cancellationToken = default)
    {
        var response = await service.GetTypesAsync(cancellationToken);
        return Ok(response);
    }
}
