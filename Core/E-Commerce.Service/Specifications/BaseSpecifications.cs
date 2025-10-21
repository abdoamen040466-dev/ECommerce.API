using System.Linq.Expressions;

namespace E_Commerce.Service.Specifications;
internal abstract class BaseSpecifications<TEntity> : ISpecification<TEntity>
    where TEntity : class
{
    protected BaseSpecifications(Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;
    }

    public ICollection<Expression<Func<TEntity, object>>> incudes { get; private set; } = [];

    public Expression<Func<TEntity, bool>> Criteria { get; private set; }

    protected void AddInclude(Expression<Func<TEntity, object>> expression)
    {
        incudes.Add(expression);
    }
}
