using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Commerce.Presistense.Repositories;
public class Repository<TEntity, TKey>(StoreDbContext dbContext) : IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
{
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();
    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsyc(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }
    public async Task<IEnumerable<TEntity>> GetAllAsyc(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await _dbSet.ApplySpecification(specification).ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }
    public async Task<TEntity?> GetAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await _dbSet.ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }

    public void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);

    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public async Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default) 
    {
         return await _dbSet.ApplySpecification(specification).CountAsync();
    }
}
