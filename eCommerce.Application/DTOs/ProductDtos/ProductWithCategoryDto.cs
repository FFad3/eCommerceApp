using eCommerce.Application.Common.Mappings;
using eCommerce.Application.DTOs.CategoryDtos;
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
        public string? ImgUrl { get; set; }
        public ShortCategoryDto Category { get; set; } = default!;
    }
}