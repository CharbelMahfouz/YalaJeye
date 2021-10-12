
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
    public class CategoryItemsController : APIBaseController
    {
        public CategoryItemsController(IUnitOfWork unit, IQueryFilter queryFilter) : base(unit, queryFilter)
        {
        }

       

        [HttpGet("{id}")]
        public  Item_VM GetItem(int id)
        {
            return  _filter.GetItem(id);
        }
    }
}
