namespace E_Commerce.Service.Specifications;
internal class ProductWithBrandTypeSpecification : BaseSpecifications<Product>
{
    public ProductWithBrandTypeSpecification()
    {
        AddInclude(p => p.ProductBrand);
        AddInclude(p => p.ProductType);
    }
}
