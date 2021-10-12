using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class RestaurantCategory
    {
        public RestaurantCategory()
        {
            Items = new HashSet<Item>();
        }

        public int CategoryId { get; set; }
        public int RestaurantId { get; set; }
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Category Category { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
