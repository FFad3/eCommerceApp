using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Persistence.Configurations
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(e => e.Order).WithMany(e => e.Items).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Product).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}