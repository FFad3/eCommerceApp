using eCommerce.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entities
{
    [Table("Categories")]
    public class Category : EntityBase
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public string Name { get; set; } = default!;
        public ICollection<Product> Products { get; set; }
    }
}