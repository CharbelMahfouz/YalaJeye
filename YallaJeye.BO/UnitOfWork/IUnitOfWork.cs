using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.BO.QueryFilter;
using YalaJeye.DAL.IRepositories;


namespace YalaJeye.BO.UnitOfWork
{
   public interface IUnitOfWork
    {
        IEventRepository EventRepository { get; }
        IMenuCategoryRepository MenuCategoryRepository { get; }
        IMenuItemRepository MenuItemRepository { get; }
        IQuickOrderRepository QuickOrderRepository { get; }
        IRestaurantRepository RestaurantRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderListRepository OrderListRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        ICustomOrderRepository CustomOrderRepository { get; }
        IPlacedQuickOrderRepository PlacedQuickOrderRepository { get; }
        IRestaurantOrderRepository RestaurantOrderRepository { get; }
        IRestaurantOrderItemRepository RestaurantOrderItemRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IAddressRepository AddressRepository { get; }
        IMapper Mapper { get; }
        Task SaveChanges();
    }
}
