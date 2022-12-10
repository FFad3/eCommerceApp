using System.Linq.Expressions;

namespace eCommerce.Application.Contracts.Persistence.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task<int> CountAsync();

        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        Task<TEntity?> FindAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        Task<IQueryable<TEntity>> AsIQuerable();

        Task<bool> IsUnique(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        Task<bool> SaveChangesAsync(CancellationToken cancellation);
    }
}