using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.Persistence.Data;
using eCommerce.Persistence.Repositories.Base;

namespace eCommerce.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}