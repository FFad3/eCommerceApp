using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.Persistence.Data;

namespace eCommerce.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}