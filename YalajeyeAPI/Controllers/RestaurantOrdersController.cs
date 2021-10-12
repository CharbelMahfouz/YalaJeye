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

namespace YalajeyeAPI.Controllers
{

    [ApiController]
    [Authorize(Roles = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RestaurantOrdersController : APIBaseController
    {
        public RestaurantOrdersController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {
        }


    }
}
