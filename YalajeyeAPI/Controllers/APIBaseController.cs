using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YalaJeye.BO.QueryFilter;
using YalaJeye.BO.UnitOfWork;

namespace YalajeyeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class APIBaseController : ControllerBase
    {
        protected readonly IUnitOfWork _unit;
        protected readonly IQueryFilter _filter;
        public APIBaseController(IUnitOfWork unit, IQueryFilter queryFilter)
        {
            _unit = unit;
            _filter = queryFilter;
        }
    }
}
