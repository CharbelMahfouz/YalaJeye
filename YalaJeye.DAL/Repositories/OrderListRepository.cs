using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.DAL.IRepositories;

using YalaJeye.DAL.Models;

namespace YalaJeye.DAL.Repositories
{
    public class OrderListRepository : GenericRepository<OrderList>, IOrderListRepository
    {
      
        
        public OrderListRepository(YallaJeyeDBContext context) : base(context)
        {
          
        }

        public async Task<OrderList> CreateOrderList(int customerId)
        {
            bool orderListExists = CheckIfOrderListExists(customerId);
            if(!orderListExists)
            {
                var orderList = new OrderList()
                {
                    CustomerId = customerId,
                     
                };
                await Create(orderList);
                return orderList;
            }
            return GetByIdWithInclude(x => x.CustomerId == customerId, x => x.Customer);
           
        }

        public bool CheckIfOrderListExists(int customerId)
        {
            var orderList = GetByIdWithInclude(x => x.CustomerId == customerId, x => x.Customer);
            if(orderList == null)
            {
                return false;
            }
            return true;
        }


    }
}
