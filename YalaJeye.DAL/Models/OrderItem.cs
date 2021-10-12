using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class OrderItem
    {
        public OrderItem()
        {
            //Cargos = new HashSet<Cargo>();
            //CustomOrders = new HashSet<CustomOrder>();
            //PlacedQuickOrders = new HashSet<PlacedQuickOrder>();
            //RestaurantOrders = new HashSet<RestaurantOrder>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public bool? IsDeleted { get; set; }
        public int OrderItemTypeId { get; set; }

        public virtual Order Order { get; set; }
        public virtual OrderItemType OrderItemType { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual CustomOrder CustomOrder { get; set; }
        public virtual PlacedQuickOrder PlacedQuickOrder { get; set; }
        public virtual RestaurantOrder RestaurantOrder { get; set; }
    }
}
