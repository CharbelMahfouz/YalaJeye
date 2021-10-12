using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class CustomOrder
    {
        public int Id { get; set; }
        public string CustomOrderTitle { get; set; }
        public string CustomOrderDetails { get; set; }
        public int OrderItemId { get; set; }

        public virtual OrderItem OrderItem { get; set; }
    }
}
