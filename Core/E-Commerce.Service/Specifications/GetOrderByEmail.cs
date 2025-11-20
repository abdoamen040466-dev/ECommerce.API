using E_Commerce.Domain.Entities.OrderEntities;

namespace E_Commerce.Service.Specifications;
internal class GetOrderByEmail
    : BaseSpecification<Order>
{
    public GetOrderByEmail(string email)
        : base(o => o.UserEmail == email)
    {
        AddInclude(o => o.Items);
    }
}
