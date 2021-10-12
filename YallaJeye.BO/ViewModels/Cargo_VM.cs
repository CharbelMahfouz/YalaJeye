using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YalaJeye.BO.ViewModels
{
    class Cargo_VM
    {
        public string CargoDescription { get; set; }
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public int VehicleTypeId { get; set; }
    }
}
