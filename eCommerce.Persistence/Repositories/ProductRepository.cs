using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.Persistence.Data;

namespace eCommerce.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}