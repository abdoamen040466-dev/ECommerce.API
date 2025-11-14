using System.Linq.Expressions;

namespace E_Commerce.Domain.Contracts;
public interface ISpecification<TEntity>
{
    Expression<Func<TEntity, bool>> Criteria { get; }
    ICollection<Expression<Func<TEntity, object>>> includes { get; }
    Expression<Func<TEntity, object>> OrderBy { get; }
    Expression<Func<TEntity, object>> OrderByDesc { get; }
    int Skip { get; }
    int Take { get; }
    bool IsPaginated { get; }

}
