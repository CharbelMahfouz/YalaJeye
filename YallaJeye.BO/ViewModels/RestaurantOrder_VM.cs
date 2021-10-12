using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.DAL.Models;

namespace YalaJeye.BO.ViewModels
{
    public class RestaurantOrder_VM
    {
        public int TotalPrice { get; set; }
        public int Id { get; set; }
        public string RestaurantName { get; set; }


        public List<RestaurantOrderItem_VM> RestaurantOrderItems { get; set; }
    }
}
