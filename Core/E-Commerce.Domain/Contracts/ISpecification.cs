using System.Linq.Expressions;

namespace E_Commerce.Domain.Contracts;
public interface ISpecification<TEntity>
{
    Expression<Func<TEntity, bool>> Criteria { get; }
    ICollection<Expression<Func<TEntity, object>>> incudes { get; }
}
