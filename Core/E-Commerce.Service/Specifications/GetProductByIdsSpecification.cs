namespace E_Commerce.Service.Specifications;
internal class GetProductByIdsSpecification(List<int> ids)
    : BaseSpecification<Product>(p => ids.Contains(p.Id));
