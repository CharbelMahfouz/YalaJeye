using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OrderStatusId { get; set; }
        public int? DeliveryPrice { get; set; }
        public int OrderNumber { get; set; }
        public int OrderListId { get; set; }
        public bool IsPlaced { get; set; }

        public virtual OrderList OrderList { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
