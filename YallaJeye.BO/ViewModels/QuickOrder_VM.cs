using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YalaJeye.BO.ViewModels
{
    public class QuickOrder_VM
    {
        public int Id { get; set; }
        public string QuickOrderName { get; set; }
        public int? Price { get; set; }
        public string PhotoUrl { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
