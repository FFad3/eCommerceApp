using eCommerce.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entities
{
    [Table("Products")]
    public class Product : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }
    }
}