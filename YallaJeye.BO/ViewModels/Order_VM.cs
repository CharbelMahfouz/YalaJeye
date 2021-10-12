
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YalaJeye.DAL.Models;

namespace YalaJeye.BO.ViewModels
{
    public class Order_VM
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OrderStatusId { get; set; }
        public int? DeliveryPrice { get; set; }
        public int OrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
    }
}
