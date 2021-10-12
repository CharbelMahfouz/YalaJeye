
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

namespace YalajeyeAPI.Controllers
{
    [ApiController]
    [Authorize(Roles = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : APIBaseController
    {
        public OrdersController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {
        }

        [HttpPost("{id}")]
        public async Task<Order_VM>  CreateOrder([FromRoute]int id)
        {
            var order = await _unit.OrderRepository.CreateOrder(id);

            Order_VM ordervm = _filter.GetOrder(order.Id);
            return ordervm;
        }

        [HttpPost("{id}")]
        public async Task PlaceOrder([FromRoute]int id)
        {
            await _unit.OrderRepository.PlaceOrder(id);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Order_VM>> GetAllOrders(int id)
        {
            return _filter.GetCustomerOrders(id);
        }

        [HttpGet("{id}")]
        public Order_VM GetOrder(int id)
        {
            return _filter.GetOrder(id);
        }

    }
}
