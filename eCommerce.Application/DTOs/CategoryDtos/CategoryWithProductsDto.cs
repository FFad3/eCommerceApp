using eCommerce.Application.Common.Mappings;
using eCommerce.Application.DTOs.ProductDtos;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.DTOs.CategoryDtos
{
    public class CategoryWithProductsDto : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();
        public int ProductsCount { get; set; }
    }
}