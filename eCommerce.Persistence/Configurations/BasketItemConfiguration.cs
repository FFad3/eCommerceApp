using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Persistence.Configurations
{
    internal class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.HasOne(e => e.Basket).WithMany(e => e.Items).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Product).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}