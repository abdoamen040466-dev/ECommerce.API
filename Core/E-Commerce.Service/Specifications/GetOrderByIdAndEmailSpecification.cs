using E_Commerce.Domain.Entities.OrderEntities;

namespace E_Commerce.Service.Specifications;
internal class GetOrderByIdAndEmailSpecification(Guid id, string email)
    : BaseSpecification<Order>(o => (o.Id == id) && (o.UserEmail == email));
