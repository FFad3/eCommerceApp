using eCommerce.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entities
{
    [Table("Baskets")]
    public class Basket : AuditableEntity
    {
        public Basket()
        {
            Items = new List<BasketItem>();
        }

        public int Id { get; set; }

        public Guid UserId { get; set; }

        public virtual IList<BasketItem> Items { get; set; }
    }
}