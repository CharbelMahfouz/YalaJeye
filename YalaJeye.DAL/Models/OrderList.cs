using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class OrderList
    {
        public OrderList()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
