using eCommerce.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entities
{
    [Table("Categories")]
    public class Category : EntityBase
    {
        public string Name { get; set; } = null!;
        public ICollection<Product> Products { get; set; } = null!;
    }
}