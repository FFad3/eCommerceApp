using eCommerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entities
{
    [Table("Orders")]
    public class Order : EntityBase
    {
        public Order()
        {
            Items = new List<OrderItem>();
        }

        public ICollection<OrderItem> Items { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }

        public Guid UserId { get; set; }
    }
}