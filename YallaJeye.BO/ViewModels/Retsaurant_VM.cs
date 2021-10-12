using System;
using System.Collections.Generic;

using YalaJeye.DAL.Models;

namespace YalaJeye.BO.Models
{
    public partial class Restaurant_VM
    {
       

        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public int CityId { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }

        public string CityName { get; set; }
        public List<RestaurantCategory> RestaurantCategories { get; set; }


    }
}
