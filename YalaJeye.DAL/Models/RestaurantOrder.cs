using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class RestaurantOrder
    {
        public RestaurantOrder()
        {
            RestaurantOrderItems = new HashSet<RestaurantOrderItem>();
        }

        public int RestaurantId { get; set; }
        public int? OrderItemId { get; set; }
        public int TotalPrice { get; set; }
        public int Id { get; set; }

        public virtual OrderItem OrderItem { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<RestaurantOrderItem> RestaurantOrderItems { get; set; }
    }
}
