using System.Linq.Expressions;

namespace E_Commerce.Service.Specifications;
internal class ProductCountSpecification : BaseSpecification<Product>
{
    public ProductCountSpecification(ProductQueryParameters parameters) : base(CreateCriteria(parameters))
    {
    }
    private static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters parameters)
    {
        return p => (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId.Value)
                    && (!parameters.TypeId.HasValue || p.TypeId == parameters.TypeId.Value)
                    && (string.IsNullOrEmpty(parameters.Search) || p.Name.Contains(parameters.Search));
    }

}
