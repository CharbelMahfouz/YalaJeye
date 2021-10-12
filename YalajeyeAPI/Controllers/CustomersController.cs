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
    public class CustomersController : APIBaseController
    {
        public CustomersController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {
        }

        [HttpPost]
        public async Task<ActionResult> CreateAddress([FromBody] Address_VM addressVM)
        {
            if(ModelState.IsValid)
            {
                Address address = _unit.Mapper.Map<Address>(addressVM);
                await _unit.AddressRepository.Create(address);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public List<Address_VM> GetCustomerAddresses(int id)
        {
            return  _filter.GetAddresses(id);
        }

    }
}
