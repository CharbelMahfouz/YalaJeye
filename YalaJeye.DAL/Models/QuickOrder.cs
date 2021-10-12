using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class QuickOrder
    {
        public int Id { get; set; }
        public string QuickOrderName { get; set; }
        public int? Price { get; set; }
        public string PhotoUrl { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual PlacedQuickOrder PlacedQuickOrder { get; set; }
    }
}
