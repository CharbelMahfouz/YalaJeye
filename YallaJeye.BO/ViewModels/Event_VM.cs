using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YalaJeye.BO.ViewModels
{
    public class Event_VM
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime? EventDate { get; set; }
        public string EventPhotoUrl { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
