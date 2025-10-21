namespace E_Commerce.Service.Specifications;
internal class ProductWithBrandTypeSpecification : BaseSpecifications<Product>
{
    public ProductWithBrandTypeSpecification()
        : base(null!)
    {
        AddInclude(p => p.ProductBrand);
        AddInclude(p => p.ProductType);
    }
    public ProductWithBrandTypeSpecification(int id)
        : base(p => p.Id == id)
    {
        AddInclude(p => p.ProductBrand);
        AddInclude(p => p.ProductType);
    }
}
