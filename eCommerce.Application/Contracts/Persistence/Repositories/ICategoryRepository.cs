using eCommerce.Domain.Entities;
using System.Linq.Expressions;

namespace eCommerce.Application.Contracts.Persistence.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category?> FindCategoryAsync(Expression<Func<Category, bool>> predicate, CancellationToken cancellationToken);
    }
}