using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Domain.Common;
using eCommerce.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.Persistence.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<TEntity> _db;

        protected GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _db = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _db.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            await _db.AddRangeAsync(entities, cancellationToken);
            return entities;
        }

        public IQueryable<TEntity> AsIQuerable()
        {
            return _db.AsQueryable();
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken)
        {
            return await _db.CountAsync(cancellationToken);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _db.CountAsync(predicate, cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _db.Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _db.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<bool> IsUnique(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var entity = await _db.FirstOrDefaultAsync(predicate, cancellationToken);
            return entity is null;
        }

        public Task Remove(TEntity entity, bool hardRemove = false)
        {
            if (hardRemove)
            {
                _db.Remove(entity);
            }
            else
            {
                entity.IsRemoved = true;
            }
            return Task.CompletedTask;
        }

        public Task Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}