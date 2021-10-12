using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime? EventDate { get; set; }
        public string EventPhotoUrl { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
