

namespace E_Commerce.Presistense.Repositories;
public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{

    private readonly Dictionary<string, object> _repositories = [];
    public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : Entity<TKey>
    {
        var typeName = typeof(TEntity).Name;
        if (_repositories.ContainsKey(typeName))
            return (_repositories[typeName] as IRepository<TEntity, TKey>)!;

        var repo = new Repository<TEntity, TKey>(dbContext);
        _repositories.Add(typeName, repo);
        return repo;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}
