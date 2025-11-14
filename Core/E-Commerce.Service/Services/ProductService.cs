using E_Commerc.ServiceAbstraction.Common;
using E_Commerce.Service.Exceptions;
using E_Commerce.Service.Specifications;
using E_Commerce.Shared.DataTransferObject;

namespace E_Commerce.Service.Services;
public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
{
    public async Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken = default)
    {
        var brands = await unitOfWork.GetRepository<ProductBrand, int>()
            .GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<BrandResponse>>(brands);
    }

    public async Task<Result<ProductResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var spec = new ProductWithBrandTypeSpecification(id);
        var product = await unitOfWork.GetRepository<Product, int>()
            .GetAsync(spec, cancellationToken);

        if (product == null)
            return Error.NotFound();

        return mapper.Map<ProductResponse>(product);

    }

    public async Task<PaginatedResult<ProductResponse>> GetProductsAsync(ProductQueryParameters parameters, CancellationToken cancellationToken = default)
    {
        var spec = new ProductWithBrandTypeSpecification(parameters);
        var data = await unitOfWork.GetRepository<Product, int>()
            .GetAllAsync(spec, cancellationToken);

        var totalCount = await unitOfWork.GetRepository<Product, int>()
            .CountAsync(new ProductCountSpecification(parameters), cancellationToken);

        var products = mapper.Map<IEnumerable<ProductResponse>>(data);
        return new(parameters.PageIndex, products.Count(), totalCount, products);
    }

    public async Task<IEnumerable<TypeResponse>> GetTypesAsync(CancellationToken cancellationToken = default)
    {
        var types = await unitOfWork.GetRepository<ProductType, int>()
            .GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<TypeResponse>>(types);
    }
}
