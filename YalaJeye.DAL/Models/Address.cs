using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class Address
    {
        public string Address1 { get; set; }
        public int CityId { get; set; }
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public virtual City City { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
