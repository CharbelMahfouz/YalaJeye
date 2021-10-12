using System;
using System.Collections.Generic;

#nullable disable

namespace YalaJeye.DAL.Models
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
            Customers = new HashSet<Customer>();
            Restaurants = new HashSet<Restaurant>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
