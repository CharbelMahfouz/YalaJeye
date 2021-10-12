using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.DAL.IRepositories;
using YalaJeye.DAL.Repositories;
using AutoMapper;
using YalaJeye.BO.QueryFilter;
using YalaJeye.BO.Mapper;
using YalaJeye.DAL.Models;

namespace YalaJeye.BO.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly YallaJeyeDBContext _context;
        public UnitOfWork(YallaJeyeDBContext context)
        {
            _context = context;
        }

        #region Private Instances
        private IEventRepository eventRepository;
        private IMenuCategoryRepository menuCategoryRepository;
        private IMenuItemRepository menuItemRepository;
        private IQuickOrderRepository quickOrderRepository;
        private IRestaurantRepository restaurantRepository;
        private IOrderRepository orderRepository;
        private IOrderListRepository orderListRepository;
        private IOrderItemRepository orderItemRepository;
        private ICustomOrderRepository customOrderRepository;
        private IPlacedQuickOrderRepository placedQuickOrderRepository;
        private IRestaurantOrderRepository restaurantOrderRepository;
        private IRestaurantOrderItemRepository restaurantOrderItemRepository;
        private ICustomerRepository customerRepository;
        private IAddressRepository addressRepository;
        private IMapper mapper;
        private IQueryFilter queryFilter;
        #endregion

        public IEventRepository EventRepository => eventRepository ?? new EventRepository(_context);

        public IMenuCategoryRepository MenuCategoryRepository => menuCategoryRepository ?? new MenuCategoryRepository(_context);

        public IMenuItemRepository MenuItemRepository => menuItemRepository ?? new MenuItemRepository(_context);

        public IQuickOrderRepository QuickOrderRepository => quickOrderRepository ?? new QuickOrderRepository(_context);

        public IRestaurantRepository RestaurantRepository => restaurantRepository ?? new RestaurantRepository(_context);
        public IOrderRepository OrderRepository => orderRepository ?? new OrderRepository(_context);
        public IOrderListRepository OrderListRepository => orderListRepository ?? new OrderListRepository(_context);
        public IOrderItemRepository OrderItemRepository => orderItemRepository ?? new OrderItemRepository(_context);
        public ICustomOrderRepository CustomOrderRepository => customOrderRepository ?? new CustomOrderRepository(_context);
        public IPlacedQuickOrderRepository PlacedQuickOrderRepository => placedQuickOrderRepository ?? new PlacedQuickOrderRepository(_context);
        public IRestaurantOrderRepository RestaurantOrderRepository => restaurantOrderRepository ?? new RestaurantOrderRepository(_context);
        public IRestaurantOrderItemRepository RestaurantOrderItemRepository => restaurantOrderItemRepository ?? new RestaurantOrderItemRepository(_context);
        public ICustomerRepository CustomerRepository => customerRepository ?? new CustomerRepository(_context);
        public IAddressRepository AddressRepository => addressRepository ?? new AddressRepository(_context);
        public IMapper Mapper
        {
            get
            {
                if (mapper == null)
                {
                    var configurationMapper = new MapperConfiguration(option => option.AddProfile(new UserProfile()));
                    return configurationMapper.CreateMapper();
                }
                else
                {
                    return mapper;
                }
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChanges()
        {
           await  _context.SaveChangesAsync();
        }
    }
}
