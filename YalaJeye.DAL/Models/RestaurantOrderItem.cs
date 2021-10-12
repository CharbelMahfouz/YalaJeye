using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class RestaurantOrderItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int RestaurantOrderId { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }

        public virtual Item Item { get; set; }
        public virtual RestaurantOrder RestaurantOrder { get; set; }
    }
}
