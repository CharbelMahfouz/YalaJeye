using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YalaJeye.BO.QueryFilter;
using YalaJeye.BO.UnitOfWork;
using YalaJeye.BO.ViewModels;
using YalaJeye.DAL.Models;

namespace YalajeyeAPI.Controllers
{

    [ApiController]
    [Authorize(Roles = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderItemsController : APIBaseController
    {
        public OrderItemsController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {
        }

        [HttpGet("{orderId}")]
        public ActionResult<IEnumerable<OrderItem_VM>> GetOrderItems(int orderId)
        {
            return _filter.GetOrderItems(orderId);
        }

        [HttpGet("{id}")]
        public dynamic GetOrderItem(int id)
        {
            var orderItem =  _filter.GetOrderItem(id);
            if(orderItem != null)
            {
                if (orderItem.OrderItemType == "Restaurant")
                {

                    var restaurantOrder = _filter.GetRestaurantOrder(orderItem.Id);
                    var restaurantOrderItems = _filter.GetRestaurantOrderItems(restaurantOrder.Id);
                    restaurantOrder.RestaurantOrderItems = restaurantOrderItems;
                    return new JsonResult(restaurantOrder);
                }

                if (orderItem.OrderItemType == "Custom")
                {
                    var customOrder = _filter.GetCustomOrder(orderItem.Id);
                    return new JsonResult(customOrder);
                }
                if(orderItem.OrderItemType == "Quick Order")
                {
                    var quickOrder = _unit.PlacedQuickOrderRepository.GetByIdWithInclude(x => x.OrderItemId == orderItem.Id, x => x.IdNavigation);
                    var quivkOrdervm = _unit.Mapper.Map<PlacedQuickOrder_VM>(quickOrder);
                    return new JsonResult(quivkOrdervm);
                }
            }
            return NotFound();
           

           
        }

        [HttpPost("id")]
        public async Task<ActionResult> CancelOrderItem([FromRoute] int id)
        {
            await _unit.OrderItemRepository.DeleteOrderItem(id);
            return Ok();
        }

        [HttpPost("{orderId}")]
        public async Task CreateCustomOrder([FromBody] CustomOrder_VM model,[FromRoute] int orderId)
        {
            var orderItem = new OrderItem()
            {
                OrderId = orderId,
                OrderItemTypeId = 1,
                IsDeleted = false,
                Title = model.CustomOrderTitle !=null ? model.CustomOrderTitle :  "Custom Order"
            };
            var createdOrderItem = await _unit.OrderItemRepository.Create(orderItem);
            model.OrderItemId = createdOrderItem.Id;
            CustomOrder customOrder = _unit.Mapper.Map<CustomOrder>(model);
            await _unit.CustomOrderRepository.Create(customOrder);
        }

        [HttpPost("{orderId}/{itemId}/{quantity}")]
        public async Task<ActionResult> CreateRestaurantOrder(int orderId, int itemId, int quantity)
        {
            var lastRestaurantOrder = _unit.RestaurantOrderRepository.GetByIdWithInclude(x => x.OrderItem.OrderId == orderId, x => x.Restaurant);
            
            var orderItem = new OrderItem()
            {
                OrderId = orderId,
                OrderItemTypeId = 2,
                IsDeleted = false,
                
            };
            var item =  _unit.MenuItemRepository.GetByIdWithInclude(x=> x.Id == itemId, x=> x.RestaurantCategory);
            if(lastRestaurantOrder != null)
            {
                if (item.RestaurantCategory.RestaurantId == lastRestaurantOrder.RestaurantId)
                {
                    

                    var newRestaurantOrderItem = new RestaurantOrderItem()
                    {
                        ItemId = item.Id,
                        Price = item.Price * quantity,
                        RestaurantOrderId = lastRestaurantOrder.Id,
                        Quantity = quantity

                    };
                   await _unit.RestaurantOrderItemRepository.Create(newRestaurantOrderItem);
                    return Ok();
                }
            } 
            
                var createdOrderItem = await _unit.OrderItemRepository.Create(orderItem);
                var restaurantOrder = new RestaurantOrder()
                {
                    RestaurantId = item.RestaurantCategory.RestaurantId,
                    OrderItemId = createdOrderItem.Id
                };
                var createdRestaurantOrder =  await _unit.RestaurantOrderRepository.Create(restaurantOrder);
                var dbRestaurantOrder = _unit.RestaurantOrderRepository.GetByIdWithInclude(x => x.Id == createdRestaurantOrder.Id, x => x.Restaurant);

                var updatedOrderItem = new OrderItem()
                {
                    OrderId = orderItem.OrderId,
                    OrderItemTypeId = orderItem.OrderItemTypeId,
                    IsDeleted = orderItem.IsDeleted,
                    Title = dbRestaurantOrder.Restaurant.RestaurantName,
                     Price = dbRestaurantOrder.TotalPrice
                };
                await _unit.OrderItemRepository.Update(updatedOrderItem);
                var restaurantOrderItem = new RestaurantOrderItem()
                {
                    ItemId = item.Id,
                    Price = item.Price * quantity,
                    RestaurantOrderId = dbRestaurantOrder.Id,
                    Quantity = quantity

                };
                
                 await _unit.RestaurantOrderItemRepository.Create(restaurantOrderItem);
            var restaurantOrderItems = _unit.RestaurantOrderItemRepository.GetAllWithPredicate(x => x.RestaurantOrderId == dbRestaurantOrder.Id);
            int totalPrice = 0;
            foreach (var restOrderItem in restaurantOrderItems)
            {
                totalPrice += (int)restOrderItem.Price;
            }
            var updatedRestaurantOrder = new RestaurantOrder()
            {
                TotalPrice = totalPrice
            };
            await _unit.RestaurantOrderRepository.Update(updatedRestaurantOrder);
                //var updatedRestaurantOrderItem = new RestaurantOrderItem()
                //{
                //    ItemId = createdRestaurantOrderItem.ItemId,
                //    Price = createdRestaurantOrderItem.Price,
                //    RestaurantOrderId = createdRestaurantOrderItem.RestaurantOrderId,

                //};
            
                return  Ok();
            
           

        }

        //[HttpPost]
        //public async Task<ActionResult> CreateCargo([FromBody] Cargo_VM)
    }
}
