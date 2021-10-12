using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YalaJeye.BO.ViewModels
{
    public class Item_VM
    {
        public string ItemName { get; set; }
        public int Id { get; set; }
        public int RestaurantCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string RestaurantName { get; set; }
        public int Price { get; set; }
        public bool? IsDeleted { get; set; }
        public string PhotoUrl { get; set; }
    }
}
