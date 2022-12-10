using eCommerce.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entities
{
    [Table("OrderItems")]
    public class OrderItem : AuditableEntity
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public Guid UserId { get; set; }

        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public string? ImgUrl { get; set; }
    }
}