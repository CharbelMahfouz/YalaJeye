using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class OrderItemType
    {
        public OrderItemType()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
