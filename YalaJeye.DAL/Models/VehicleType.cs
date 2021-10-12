using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Cargos = new HashSet<Cargo>();
        }

        public int Id { get; set; }
        public string VehicleType1 { get; set; }

        public virtual ICollection<Cargo> Cargos { get; set; }
    }
}
