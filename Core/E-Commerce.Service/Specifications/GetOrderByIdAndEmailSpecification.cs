using E_Commerce.Domain.Entities.OrderEntities;

namespace E_Commerce.Service.Specifications;
internal class GetOrderByIdAndEmailSpecification
    : BaseSpecification<Order>
{
    public GetOrderByIdAndEmailSpecification(Guid id, string email)
        : base(o => (o.Id == id) && (o.UserEmail == email))
    {
        AddInclude(o => o.Items);
    }
}
