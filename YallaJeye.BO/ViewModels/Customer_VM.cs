using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.DAL.Models;

namespace YalaJeye.BO.ViewModels
{
   public class Customer_VM
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PhotoUrl { get; set; }
        public string CityName { get; set; }
        public string UserId { get; set; }
        public string token { get; set; }
       
    }
}
