using eCommerce.Application.Common.Mappings;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.DTOs.CategoryDtos
{
    public class CategoryDto : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}