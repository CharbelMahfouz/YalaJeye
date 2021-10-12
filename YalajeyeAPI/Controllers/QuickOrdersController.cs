
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
    public class QuickOrdersController : APIBaseController
    {
        public QuickOrdersController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuickOrder_VM>>> GetQuickOrders()
        {
            return await _filter.GetQuickOrders();
        }

        [HttpGet("{id}")]
        public async Task<QuickOrder_VM> GetQuickOrder(int id)
        {
            return await _filter.GetQuickOrderById(id);
        }

        [HttpPost("{quickOrderId}/{quantity}/{orderId}")]
        [Authorize(Roles = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> PlaceQuickOrder([FromRoute] int quickOrderId, [FromRoute] int quantity, [FromRoute] int orderId)
        {
            var quickOrder = await _unit.QuickOrderRepository.GetById(quickOrderId);
            var newOrderItem = new OrderItem()
            {
                OrderId = orderId,
                 Title = quickOrder.QuickOrderName,
                  Price = (int)(quickOrder.Price * quantity)
            };
            var orderItem = await _unit.OrderItemRepository.Create(newOrderItem);
            var placedQuickOrder = new PlacedQuickOrder()
            {
                QuickOrderId = quickOrderId,
                Quantity = quantity,
                OrderItemId = orderItem.Id,
                 
            };

            await _unit.PlacedQuickOrderRepository.Create(placedQuickOrder);
            return Ok();
        }
    }
}
