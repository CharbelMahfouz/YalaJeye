using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.DAL.IRepositories;
using YalaJeye.DAL.Models;

namespace YalaJeye.DAL.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
      
        public OrderItemRepository(YallaJeyeDBContext context) : base(context)
        {
           
        }

        public async Task DeleteOrderItem(int id)
        {
            var orderItem = await GetById(id);
            orderItem.IsDeleted = true;
            await Update(orderItem);
        }
    }
}
