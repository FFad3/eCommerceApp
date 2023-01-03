using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Category?> GetCategoryWithProductsAsync(Expression<Func<Category, bool>> predicate, CancellationToken cancellationToken)
        {
            var result = await _db.Include(x => x.Products).FirstOrDefaultAsync(predicate, cancellationToken);
            return result;
        }
    }
}