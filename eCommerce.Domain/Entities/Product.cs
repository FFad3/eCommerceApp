using eCommerce.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entities
{
    [Table("Products")]
    public class Product : EntityBase
    {
        public string Name { get; set; } = default!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        public decimal Price { get; set; }

        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
    }
}