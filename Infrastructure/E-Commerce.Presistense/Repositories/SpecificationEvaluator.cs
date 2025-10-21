namespace E_Commerce.Presistense.Repositories;
internal static class SpecificationEvaluator
{
    public static IQueryable<TEntity> ApplySpecification<TEntity>(this IQueryable<TEntity> inputQuery,
        ISpecification<TEntity> specification)
        where TEntity : class
    {
        var query = inputQuery;
        if (specification.Criteria is not null)
            query = query.Where(specification.Criteria);

        query = specification.incudes
            .Aggregate(query, (query, include) => query.Include(include));
        return query;
    }
}
