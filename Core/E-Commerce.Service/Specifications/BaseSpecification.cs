using System.Linq.Expressions;

namespace E_Commerce.Service.Specifications;
internal abstract class BaseSpecification<TEntity> : ISpecification<TEntity>
    where TEntity : class
{
    protected BaseSpecification(Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;
    }

    public ICollection<Expression<Func<TEntity, object>>> incudes { get; private set; } = [];

    public Expression<Func<TEntity, bool>> Criteria { get; private set; }

    public Expression<Func<TEntity, object>> OrderBy { get; private set; }

    public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }

    public int Skip { get; private set; }

    public int Take { get; private set; }

    public bool IsPaginated { get; private set; }

    protected void ApplyPagination(int pageSize, int pageIndex)
    {
        IsPaginated = true;
        Skip = (pageIndex - 1) * pageSize;
        Take = pageSize;
    }
    protected void AddInclude(Expression<Func<TEntity, object>> expression)
    {
        incudes.Add(expression);
    }

    protected void AddOrderBy(Expression<Func<TEntity, object>> expression)
    {
        OrderBy = expression;
    }
    protected void AddOrderByDesc(Expression<Func<TEntity, object>> expression)
    {
        OrderByDesc = expression;
    }
}
