
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

    public class OrderListsController : APIBaseController
    {
        public OrderListsController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {
        }

        [HttpGet("{id}")]
        public  OrderList_VM GetOrderList(int id)
        {
            return  _filter.GetOrderList(id);
        }

        [HttpPost("{customerId}")]
        public async Task<OrderList_VM> CreateOrderList(int id)
        {
            var orderList = await _unit.OrderListRepository.CreateOrderList(id);
            OrderList_VM orderListvm = _unit.Mapper.Map<OrderList_VM>(orderList);
            return orderListvm;
        }
    }
}
