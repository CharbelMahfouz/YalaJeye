using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class Cargo
    {
        public string CargoDescription { get; set; }
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public int VehicleTypeId { get; set; }

        public virtual OrderItem OrderItem { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}
