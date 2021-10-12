using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YalaJeye.BO.ViewModels
{
    public class CustomOrder_VM
    {
        public int Id { get; set; }
        public string CustomOrderTitle { get; set; }
        public string CustomOrderDetails { get; set; }
        public int OrderItemId { get; set; }
    }
}
