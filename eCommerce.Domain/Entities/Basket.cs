using eCommerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entities
{
    [Table("Baskets")]
    public class Basket : EntityBase
    {
        public Basket()
        {
            Items = new List<BasketItem>();
        }

        public Guid UserId { get; set; }

        public ICollection<BasketItem> Items { get; set; }
    }
}