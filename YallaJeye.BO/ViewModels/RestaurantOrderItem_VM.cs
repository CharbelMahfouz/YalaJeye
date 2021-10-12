using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YalaJeye.BO.ViewModels
{
   public class RestaurantOrderItem_VM
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string RestaurantName { get; set; }
    }
}
