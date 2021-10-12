using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.DAL.IRepositories;
using YalaJeye.DAL.Models;

namespace YalaJeye.DAL.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly YallaJeyeDBContext _context;
        public OrderRepository(YallaJeyeDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrder(int orderListId)
        {
            
            var lastOrder = GetAllWithInclude(x => x.OrderListId == orderListId, x=> x.OrderStatus).OrderByDescending(x => x.CreatedAt).FirstOrDefault();
            if(lastOrder != null)
            {
                if (lastOrder.OrderStatus.StatusName == "Delivered")
                {
                    var newOrder = new Order()
                    {
                        OrderListId = orderListId,
                        CreatedAt = DateTime.Now,
                        OrderStatusId = 1,
                        DeliveryPrice = null,
                        OrderNumber = lastOrder.OrderNumber + 1
                    };
                    await Create(newOrder);
                    return newOrder;
                } else
                {
                    var currentOrder = GetByIdWithInclude(x => x.OrderListId == orderListId, x => x.OrderStatus);
                    return currentOrder;
                }

            }

            var order = new Order()
            {
                OrderListId = orderListId,
                CreatedAt = DateTime.Now,
                OrderStatusId = 1,
                DeliveryPrice = null,
                OrderNumber = 1
            };
            await Create(order);
            return order;
        }

        public async Task PlaceOrder(int id)
        {
            var order = await GetById(id);
            order.IsPlaced = true;
            await Update(order);
        }
    }
}
