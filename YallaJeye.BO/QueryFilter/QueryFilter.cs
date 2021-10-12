
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.BO.Models;
using YalaJeye.BO.UnitOfWork;
using YalaJeye.BO.ViewModels;

namespace YalaJeye.BO.QueryFilter
{
    public class QueryFilter : IQueryFilter
    {
        private readonly IUnitOfWork _unit;

        public QueryFilter(IUnitOfWork unit)
        {
            _unit = unit;
        }

        #region Events
        public async Task<List<Event_VM>> GetEvents()
        {
            var events = _unit.EventRepository.GetAllWithPredicate(x=> x.IsDeleted ==  false);
            List<Event_VM> eventsvm = await (from e in events select _unit.Mapper.Map<Event_VM>(e)).ToListAsync();
            return eventsvm;
        }

        public async Task<Event_VM> GetEventById(int id)
        {
            var e = _unit.Mapper.Map<Event_VM>(await _unit.EventRepository.GetById(id));
            return e;
        }
        #endregion

        #region Restaurants
        public  List<Restaurant_VM> GetRestaurants()
        {
            var restaurants =   _unit.RestaurantRepository.GetAllWithInclude(x=> x.IsDeleted ==  false, x=> x.City);
            List<Restaurant_VM> restaurantsvm =  (from r in restaurants select _unit.Mapper.Map<Restaurant_VM>(r)).ToList();
            return restaurantsvm;
        }

        public  Restaurant_VM GetRestaurantById(int id)
        {
            var restaurant = _unit.Mapper.Map<Restaurant_VM>( _unit.RestaurantRepository.GetByIdWithInclude(x=> x.Id == id, x=> x.City));
            return restaurant;
        }
        #endregion

        #region QuickOrders

        public async Task<List<QuickOrder_VM>> GetQuickOrders()
        {
            var quickOrders = _unit.QuickOrderRepository.GetAll();
            List<QuickOrder_VM> quickOrdersvm = await (from q in quickOrders select _unit.Mapper.Map<QuickOrder_VM>(q)).ToListAsync();
            return quickOrdersvm;
        }

        public async Task<QuickOrder_VM> GetQuickOrderById(int id)
        {
            var quickOrder = _unit.Mapper.Map<QuickOrder_VM>(await _unit.QuickOrderRepository.GetById(id));
            return quickOrder;
        }
        #endregion

        #region Menu Categories
        public  List<RestaurantCategory_VM> GetRestaurantMenuCategories(int id)
        {
            var menuCategories =  _unit.MenuCategoryRepository.GetAllWithInclude(x=> x.RestaurantId == id, x=> x.Restaurant, x=> x.Category);
            List<RestaurantCategory_VM> menuCategoriesvm =  (from c in menuCategories select _unit.Mapper.Map<RestaurantCategory_VM>(c)).ToList();
            return menuCategoriesvm;
        }


        #endregion

        #region Menu Items
        public  List<Item_VM> GetCategoryItems(int id)
        {
            var categoryItems =  _unit.MenuItemRepository.GetByCategory(id);
            List<Item_VM> categoryItemsvm =  (from c in categoryItems select _unit.Mapper.Map<Item_VM>(c)).ToList();
            return categoryItemsvm;
        }

        public  Item_VM GetItem(int id)
        {
            var item = _unit.Mapper.Map<Item_VM>( _unit.MenuItemRepository.GetByIdWithInclude(x=> x.Id == id, x=> x.RestaurantCategory));
            return item;
        }
        #endregion

        #region Orders
        public List<Order_VM> GetCustomerOrders(int orderListId)
        {
            var orders = _unit.OrderRepository.GetAllWithInclude(x => x.OrderListId == orderListId, x => x.OrderStatus);
            List<Order_VM> ordersvm = (from o in orders select _unit.Mapper.Map<Order_VM>(o)).ToList();
            return ordersvm;
        } 

        public Order_VM GetOrder(int id)
        {
            var order = _unit.Mapper.Map<Order_VM>(_unit.OrderRepository.GetByIdWithInclude(x => x.Id == id, x => x.OrderStatus));
            return order;
        }

        public List<Order_VM> GetAllOrders()
        {
            var orders = _unit.OrderRepository.GetAllWithInclude(x => x.IsPlaced == true, x => x.OrderItems, x => x.OrderList, x => x.OrderList.Customer);
            List<Order_VM> ordersvm = (from o in orders select _unit.Mapper.Map<Order_VM>(o)).ToList();
            return ordersvm;
        }
        #endregion

        #region OrderList
        public OrderList_VM GetOrderList(int customerId)
        {
            var orderList = _unit.Mapper.Map<OrderList_VM>(_unit.OrderListRepository.GetByIdWithInclude(x => x.CustomerId == customerId, x => x.Customer));
            return orderList;
        }
        #endregion

        #region OrderItems
        public List<OrderItem_VM> GetOrderItems(int orderId)
        {
            var orderItems = _unit.OrderItemRepository.GetAllWithInclude(x => x.OrderId == orderId && x.IsDeleted == false, x => x.PlacedQuickOrder,x=> x.PlacedQuickOrder.IdNavigation, x=> x.RestaurantOrder,x=> x.RestaurantOrder.Restaurant, x=>x.CustomOrder, x=> x.Cargo);
            List<OrderItem_VM> orderItemsvm = (from o in orderItems select _unit.Mapper.Map<OrderItem_VM>(o)).ToList();
            return orderItemsvm;
        }

        public OrderItem_VM GetOrderItem(int id)
        {
            var orderItem = _unit.Mapper.Map<OrderItem_VM>(_unit.OrderItemRepository.GetByIdWithInclude(x => x.Id == id, x=> x.OrderItemType,x => x.PlacedQuickOrder, x => x.RestaurantOrder, x => x.CustomOrder));
            return orderItem;
        }

        public RestaurantOrder_VM GetRestaurantOrder(int orderItemId)
        {
           var restaurantOrder = _unit.RestaurantOrderRepository.GetByIdWithInclude(x => x.OrderItemId == orderItemId, x => x.RestaurantOrderItems, x => x.Restaurant);
            var restaurantOrdervm = _unit.Mapper.Map<RestaurantOrder_VM>(restaurantOrder);
            return restaurantOrdervm;
        }

        public List<RestaurantOrderItem_VM> GetRestaurantOrderItems(int restaurantOrderId)
        {
            var restaurantOrderItems = _unit.RestaurantOrderItemRepository.GetAllWithInclude(x => x.RestaurantOrderId == restaurantOrderId, x => x.Item);
            List<RestaurantOrderItem_VM> restaurantOrderItemsvm = (from r in restaurantOrderItems select _unit.Mapper.Map<RestaurantOrderItem_VM>(r)).ToList();
            return restaurantOrderItemsvm;
        }

        public CustomOrder_VM GetCustomOrder(int orderItemId)
        {
            var customOrder = _unit.Mapper.Map<CustomOrder_VM>(_unit.CustomOrderRepository.GetByIdWithInclude(x => x.OrderItemId == orderItemId));
            return customOrder;
        }

        public PlacedQuickOrder_VM GetPlacedQuickOrder(int orderItemId)
        {
            var placedQuickOrder = _unit.Mapper.Map<PlacedQuickOrder_VM>(_unit.PlacedQuickOrderRepository.GetByIdWithInclude(x => x.OrderItemId == orderItemId, x => x.IdNavigation));
            return placedQuickOrder;
        }
        #endregion

        #region Addresses
        public List<Address_VM> GetAddresses(int id)
        {
            var addresses = _unit.AddressRepository.GetAllWithInclude(x => x.CustomerId == id, x => x.City);
            List<Address_VM> addressesvm = (from a in addresses select _unit.Mapper.Map<Address_VM>(a)).ToList();
            return addressesvm;
        }
        #endregion
    }
}
