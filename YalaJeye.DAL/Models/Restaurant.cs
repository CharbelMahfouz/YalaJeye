using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            RestaurantCategories = new HashSet<RestaurantCategory>();
            RestaurantOrders = new HashSet<RestaurantOrder>();
        }

        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public int CityId { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<RestaurantCategory> RestaurantCategories { get; set; }
        public virtual ICollection<RestaurantOrder> RestaurantOrders { get; set; }
    }
}
