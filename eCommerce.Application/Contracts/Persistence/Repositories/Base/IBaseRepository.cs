using System.Linq.Expressions;

namespace eCommerce.Application.Contracts.Persistence.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Add single element
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Add multiple elements
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

        /// <summary>
        /// Remove specific element
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Remove(TEntity entity);

        /// <summary>
        /// Update specific element
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Update(TEntity entity);

        /// <summary>
        /// Returns count of elemts
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Returns count of elemts that fulfill condition
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        /// <summary>
        /// Returns element that fulfill predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        /// <summary>
        /// Returns all elements that fulfill predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity?>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        /// <summary>
        /// Returns dbset as IQuerable
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> AsIQuerable();

        /// <summary>
        /// Check if given field is unique
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> IsUnique(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        /// <summary>
        /// Save DbContextChanges
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<bool> SaveChangesAsync(CancellationToken cancellation);
    }
}