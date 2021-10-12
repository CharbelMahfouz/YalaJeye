using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.DAL.IRepositories;
using YalaJeye.DAL.Models;

namespace YalaJeye.DAL.Repositories
{
   public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(YallaJeyeDBContext context) : base(context)
        {
        }
    }
}
