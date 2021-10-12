using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class PlacedQuickOrder
    {
        public int Id { get; set; }
        public int QuickOrderId { get; set; }
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }

        public virtual QuickOrder IdNavigation { get; set; }
        public virtual OrderItem OrderItem { get; set; }
    }
}
