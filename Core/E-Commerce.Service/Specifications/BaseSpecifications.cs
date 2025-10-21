using System.Linq.Expressions;

namespace E_Commerce.Service.Specifications;
internal abstract class BaseSpecifications<TEntity> : ISpecification<TEntity>
    where TEntity : class
{
    public ICollection<Expression<Func<TEntity, object>>> incudes { get; private set; } = [];
    protected void AddInclude(Expression<Func<TEntity, object>> expression)
    {
        incudes.Add(expression);
    }
}
