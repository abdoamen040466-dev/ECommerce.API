using E_Commerce.Domain.Entities.OrderEntities;

namespace E_Commerce.Service.Specifications;
internal class GetOrderByEmail(string email)
    : BaseSpecification<Order>(o => o.UserEmail == email);
