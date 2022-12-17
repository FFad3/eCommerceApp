using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Persistence.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(e => e.Category).WithMany(e => e.Products).OnDelete(DeleteBehavior.NoAction);
            builder.Property(p => p.Description).HasColumnType("nvarchar(600)");
        }
    }
}