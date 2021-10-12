using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class Item
    {
        public Item()
        {
            RestaurantOrderItems = new HashSet<RestaurantOrderItem>();
        }

        public string ItemName { get; set; }
        public int Id { get; set; }
        public int RestaurantCategoryId { get; set; }
        public int Price { get; set; }
        public bool? IsDeleted { get; set; }
        public string PhotoUrl { get; set; }

        public virtual RestaurantCategory RestaurantCategory { get; set; }
        public virtual ICollection<RestaurantOrderItem> RestaurantOrderItems { get; set; }
    }
}
