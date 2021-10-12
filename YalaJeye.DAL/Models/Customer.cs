using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();
            OrderLists = new HashSet<OrderList>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PhotoUrl { get; set; }
        public int CityId { get; set; }
        public string UserId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<OrderList> OrderLists { get; set; }
    }
}
