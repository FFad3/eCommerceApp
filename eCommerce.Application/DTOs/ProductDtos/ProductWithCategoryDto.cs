using eCommerce.Application.Common.Mappings;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.DTOs.ProductDtos
{
    public class ProductWithCategoryDto : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public string CategoryName { get; set; } = default!;

        public decimal Price { get; set; }

        public string? Description { get; set; }
    }
}