using eCommerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entities
{
    [Table("BasketItems")]
    public class BasketItem : EntityBase
    {
        public int BastekId { get; set; }
        public Basket Basket { get; set; } = default!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public string ProductName { get; set; } = default!;

        public Guid UserId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}