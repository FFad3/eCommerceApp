﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entities
{
    [Table("Orders")]
    public class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();
        }

        public int Id { get; set; }
        public virtual IList<OrderItem> Items { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }

        public Guid UserId { get; set; }
    }
}