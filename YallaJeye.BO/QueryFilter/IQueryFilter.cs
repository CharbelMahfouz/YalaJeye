

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YalaJeye.BO.Models;
using YalaJeye.BO.ViewModels;

namespace YalaJeye.BO.QueryFilter
{
    public interface IQueryFilter
    {
        List<Item_VM> GetCategoryItems(int id);
        Task<Event_VM> GetEventById(int id);
        Task<List<Event_VM>> GetEvents();
        Item_VM GetItem(int id);
        Task<QuickOrder_VM> GetQuickOrderById(int id);
        Task<List<QuickOrder_VM>> GetQuickOrders();
        Restaurant_VM GetRestaurantById(int id);
        List<RestaurantCategory_VM> GetRestaurantMenuCategories(int id);
        List<Restaurant_VM> GetRestaurants();
        List<Order_VM> GetCustomerOrders(int orderListId);
        List<Order_VM> GetAllOrders();
        Order_VM GetOrder(int id);
        OrderList_VM GetOrderList(int customerId);
        List<OrderItem_VM> GetOrderItems(int orderId);
        OrderItem_VM GetOrderItem(int id);

        List<Address_VM> GetAddresses(int id);
        RestaurantOrder_VM GetRestaurantOrder(int orderItemId);
        List<RestaurantOrderItem_VM> GetRestaurantOrderItems(int restaurantOrderId);
        CustomOrder_VM GetCustomOrder(int orderItemId);
        PlacedQuickOrder_VM GetPlacedQuickOrder(int orderItemId);
    }
}