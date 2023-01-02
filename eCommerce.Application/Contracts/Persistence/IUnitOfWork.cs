using eCommerce.Application.Contracts.Persistence.Repositories;

namespace eCommerce.Application.Contracts.Persistence
{
    /// <summary>
    /// UnitOfWork for menage repositories
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets Category repository
        /// </summary>
        ICategoryRepository Category { get; }

        /// <summary>
        /// Gets Product repository
        /// </summary>
        IProductRepository Product { get; }

        /// <summary>
        /// Gets Order repository
        /// </summary>
        IOrderRepository Order { get; }

        /// <summary>
        /// Gets OrderItem repository
        /// </summary>
        IOrderItemRepository OrderItem { get; }

        /// <summary>
        /// Gets BasketItem repository
        /// </summary>
        IBasketItemRepository BasketItem { get; }

        /// <summary>
        /// Gets Basket repository
        /// </summary>
        IBasketRepository Basket { get; }

        /// <summary>
        /// Save DbContextChanges
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<bool> SaveChangesAsync(CancellationToken cancellation);
    }
}