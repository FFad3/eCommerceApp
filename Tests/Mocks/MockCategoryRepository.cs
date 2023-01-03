using eCommerce.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using Moq;
using System.Linq.Expressions;

namespace Tests.Mocks
{
    public static class GenericMockRepository<TEntity> where TEntity : EntityBase
    {
        public static Mock<IGenericRepository<TEntity>> GetGenericRepository(IQueryable<TEntity> querable)
        {
            var mockRepo = new Mock<IGenericRepository<TEntity>>();

            #region setup

            mockRepo.Setup(r => r.AddAsync(It.IsAny<TEntity>(), It.IsAny<CancellationToken>())).ReturnsAsync((TEntity entity) =>
            {
                querable.ToList().Add(entity);
                return entity;
            });
            mockRepo.Setup(r => r.AddRangeAsync(It.IsAny<IEnumerable<TEntity>>(), It.IsAny<CancellationToken>())).ReturnsAsync((IEnumerable<TEntity> entities) =>
            {
                querable.ToList().AddRange(entities);
                return entities;
            });
            mockRepo.Setup(r => r.Remove(It.IsAny<TEntity>(), It.IsAny<bool>())).Returns((TEntity entity) =>
            {
                querable.ToList().Remove(entity);
                return Task.CompletedTask;
            });
            mockRepo.Setup(r => r.Update(It.IsAny<TEntity>())).Returns((TEntity entity) =>
            {
                var x = querable.FirstOrDefault(x => x.Id == entity.Id);
                if (x is not null)
                {
                    querable.ToList().Remove(x);
                }
                return Task.CompletedTask;
            });
            mockRepo.Setup(r => r.CountAsync(It.IsAny<CancellationToken>())).Returns((CancellationToken cancellationToken) => querable.CountAsync(cancellationToken));
            mockRepo.Setup(r => r.CountAsync(It.IsAny<Expression<Func<TEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .Returns((Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken) => querable.CountAsync(predicate, cancellationToken));
            mockRepo.Setup(r => r.FindAsync(It.IsAny<Expression<Func<TEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .Returns((Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken) => querable.FirstOrDefaultAsync(predicate, cancellationToken));
            mockRepo.Setup(r => r.FindAllAsync(It.IsAny<Expression<Func<TEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .Returns((Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken) => querable.Where(predicate).ToListAsync(cancellationToken));
            mockRepo.Setup(r => r.AsIQuerable()).Returns(querable);
            mockRepo.Setup(r => r.IsUnique(It.IsAny<Expression<Func<TEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .Returns((Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken) => querable.FirstOrDefaultAsync(predicate, cancellationToken));

            #endregion setup

            return mockRepo;
        }
    }

    public static class MockCategoryRepository
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id=1,
                    Name="Category1"
                },
                new Category
                {
                    Id=2,
                    Name="Category2"
                },
                new Category
                {
                    Id=3,
                    Name="Category3"
                },
                new Category
                {
                    Id=4,
                    Name="Category4"
                }
            }.AsQueryable();
            var genericMock = GenericMockRepository<Category>.GetGenericRepository(categories);
            var mockRepo = genericMock.As<ICategoryRepository>();
            //var mockRepo = new Mock<ICategoryRepository>();

            return mockRepo;
        }
    }
}