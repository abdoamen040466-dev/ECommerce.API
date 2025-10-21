using System.Linq.Expressions;

namespace E_Commerce.Domain.Contracts;
public interface ISpecification<TEntity>
{
    ICollection<Expression<Func<TEntity, object>>> incudes { get; }
}
