using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            RestaurantCategories = new HashSet<RestaurantCategory>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<RestaurantCategory> RestaurantCategories { get; set; }
    }
}
