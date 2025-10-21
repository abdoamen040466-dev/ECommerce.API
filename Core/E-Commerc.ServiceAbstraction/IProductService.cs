using E_Commerce.Shared.DataTransferObject;
using E_Commerce.Shared.DataTransferObject.Products;

namespace E_Commerc.ServiceAbstraction;
public interface IProductService
{
    Task<ProductResponse?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PaginatedResult<ProductResponse>> GetProductsAsync(ProductQueryParameters parameters, CancellationToken cancellationToken = default);
    Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<TypeResponse>> GetTypesAsync(CancellationToken cancellationToken = default);

}
