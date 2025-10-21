using System.Linq.Expressions;

namespace E_Commerce.Service.Specifications;
internal class ProductWithBrandTypeSpecification : BaseSpecifications<Product>
{
    public ProductWithBrandTypeSpecification(ProductQueryParameters parameters)
        : base(CreateCriteria(parameters))
    {
        AddInclude(p => p.ProductBrand);
        AddInclude(p => p.ProductType);
    }


    private static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters parameters)
    {
        return p => (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId.Value)
                    && (!parameters.TypeId.HasValue || p.TypeId == parameters.TypeId.Value)
                    && (string.IsNullOrEmpty(parameters.Search) || p.Name.Contains(parameters.Search));
    }

    public ProductWithBrandTypeSpecification(int id)
        : base(p => p.Id == id)
    {
        AddInclude(p => p.ProductBrand);
        AddInclude(p => p.ProductType);
    }
}
