
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
    public class EventsController : APIBaseController
    {
        public EventsController(IUnitOfWork unit, IQueryFilter filter) : base(unit, filter)
        {

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event_VM>>> GetEvents()
        {
            return await _filter.GetEvents();
        }

        [HttpGet("{id}")]
        public async Task<Event_VM> GetEvent(int id)
        {
            return await _filter.GetEventById(id);
        }
    }
}
