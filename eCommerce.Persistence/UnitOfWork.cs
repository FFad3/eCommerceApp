using eCommerce.Application.Contracts.Persistence;
using eCommerce.Application.Contracts.Persistence.Repositories;
using eCommerce.Persistence.Data;
using eCommerce.Persistence.Repositories;

namespace eCommerce.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICategoryRepository? _categoryRepository;
        private readonly IProductRepository? _productRepository;
        private readonly IOrderRepository? _orderRepository;
        private readonly IOrderItemRepository? _orderItemRepository;
        private readonly IBasketItemRepository? _basketItemRepository;
        private readonly IBasketRepository? _basketRepository;
        private bool disposed = false;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICategoryRepository Category => _categoryRepository ?? new CategoryRepository(_dbContext);

        public IProductRepository Product => _productRepository ?? new ProductRepository(_dbContext);

        public IOrderRepository Order => throw new NotImplementedException();

        public IOrderItemRepository OrderItem => throw new NotImplementedException();

        public IBasketItemRepository BasketItem => throw new NotImplementedException();

        public IBasketRepository Basket => throw new NotImplementedException();

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _dbContext.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellation)
        {
            return await _dbContext.SaveChangesAsync(cancellation) > 0;
        }
    }
}