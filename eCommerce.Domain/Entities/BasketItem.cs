using eCommerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entities
{
    [Table("BasketItems")]
    public class BasketItem : AuditableEntity
    {
        public int Id { get; set; }

        public int BastekId { get; set; }
        public Basket Basket { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public string ProductName { get; set; } = null!;

        public Guid UserId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? ImgUrl { get; set; }
    }
}