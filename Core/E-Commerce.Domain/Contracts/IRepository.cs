using E_Commerce.Domain.Entities;

namespace E_Commerce.Domain.Contracts;
public interface IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
{
    public void Add(TEntity entity);
    public void Remove(TEntity entity);
    public void Update(TEntity entity);
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
    Task<TEntity?> GetAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAllAsyc(CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAllAsyc(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
    Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
}
