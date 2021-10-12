
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YalaJeye.DAL.Models;

namespace YalaJeye.BO.ViewModels
{
    public class OrderItem_VM
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int CustomerId { get; set; }

        public string OrderItemType { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        
        public CustomOrder CustomOrder { get; set; }
        public PlacedQuickOrder PlacedQuickOrder { get; set; }
        public RestaurantOrder RestaurantOrder { get; set; }
    }
}
