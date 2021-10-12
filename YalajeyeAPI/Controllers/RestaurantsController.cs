
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YalaJeye.BO.QueryFilter;
using YalaJeye.BO.UnitOfWork;
using YalaJeye.BO.ViewModels;
using YalaJeye.BO.Models;

namespace YalajeyeAPI.Controllers
{
    public class RestaurantsController : APIBaseController
    {
        public RestaurantsController(IUnitOfWork unit, IQueryFilter filter) : base(unit, filter)
        {

        }

        [HttpGet]
        public  ActionResult<IEnumerable<Restaurant_VM>> GetRestaurants()
        {
            return  _filter.GetRestaurants();
        }

        [HttpGet("{id}")]
        public  Restaurant_VM GetRestaurant(int id)
        {
            return  _filter.GetRestaurantById(id);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<RestaurantCategory_VM>> GetMenuCategories(int id)
        {
            return _filter.GetRestaurantMenuCategories(id);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Item_VM>> GetCategoryItems(int id)
        {
            return _filter.GetCategoryItems(id);
        }
    }
}
