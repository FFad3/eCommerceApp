using eCommerce.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entities
{
    [Table("Categories")]
    public class Category : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}