using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YalaJeye.Admin.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YalaJeye.DAL.Models;
using YalaJeye.BO.ViewModels;
using YalaJeye.BO.Models;
using YalaJeye.BO.QueryFilter;
using YalaJeye.BO.UnitOfWork;

namespace YalaJeye.Admin.Controllers
{
    public class AdminController : Controller
    {
        private static Random random = new Random();
        public static YallaJeyeDBContext _context;
        public static ApplicationDbContext _context2;
        private readonly IQueryFilter _filter;
        private readonly IUnitOfWork _unit;

        public AdminController(YallaJeyeDBContext context, ApplicationDbContext context2, IQueryFilter filter, IUnitOfWork unit)
        {
            _context = context;
            _context2 = context2;
            _filter = filter;
            _unit = unit;

        }


        [Authorize]
        public IActionResult Index()
        {
            ViewBag.HeadTitle = "Admin Dashboard";
            return View();
        }

        #region Restaurants
        public ActionResult Restaurants()
        {
            List<RestaurantCategory> restaurantCategories = _context.RestaurantCategories.Where(x=> x.IsDeleted ==  false).ToList();
            List<Restaurant_VM> restaurants = _context.Restaurants.Where(x => x.IsDeleted == false).Select(x => new Restaurant_VM()
            {
                CityId = x.CityId,
                CityName = x.City.CityName,
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                PhotoUrl = x.PhotoUrl,
                RestaurantName = x.RestaurantName,
                RestaurantCategories = restaurantCategories

            }).ToList();


            return View(restaurants);
        }


        public ActionResult CreateRestaurant()
        {

            ViewBag.Cities = _context.Cities.ToList();
            return View();
        }

        public async Task<string> SaveRestaurant()
        {

            try
            {
                var newSubcat = new Restaurant();
                newSubcat.IsDeleted = false;
                newSubcat.CityId = Convert.ToInt32(Request.Form["CityId"]);
                newSubcat.PhoneNumber = Request.Form["PhoneNumber"];
                newSubcat.RestaurantName = Request.Form["RestaurantName"].ToString();
                var file = Request.Form.Files["PhotoUrl"];
                if (file != null)
                {
                    var NewFileName = RandomStringNoCharacters(20) + file.FileName.ToString();

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", NewFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    newSubcat.PhotoUrl = NewFileName;
                }
                if (Request.Form["Id"].ToString() == "0")
                {
                    _context.Restaurants.Add(newSubcat);
                    _context.SaveChanges();
                    return newSubcat.Id.ToString();
                }
                else
                {
                    int currID = Convert.ToInt32(Request.Form["Id"]);
                    var currBanner = _context.Restaurants.Where(x => x.Id == currID).FirstOrDefault();
                    if (newSubcat.PhotoUrl != null)
                    {
                        currBanner.PhotoUrl = newSubcat.PhotoUrl;
                    }
                    currBanner.PhoneNumber = newSubcat.PhoneNumber;
                    currBanner.CityId = newSubcat.CityId;
                    currBanner.RestaurantName = newSubcat.RestaurantName;
                    _context.SaveChanges();
                    return currBanner.Id.ToString();
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }

        }

        public string DeleteRestaurant()
        {

            var ItemID = Convert.ToInt32(Request.Form["ID"]);
            var currBanner = _context.Restaurants.Where(x => x.Id == ItemID).FirstOrDefault();
            currBanner.IsDeleted = true;
            _context.SaveChanges();
            return "Deleted";
        }


        public ActionResult Restaurant(int id)
        {
            Restaurant restaurant = _context.Restaurants.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.Cities = _context.Cities.ToList();
            if (restaurant == null)
            {
                return RedirectToAction("Restaurants");
            }
            return View(restaurant);

        }
        #endregion


        #region Categories
        public ActionResult Categories()
        {
            var categories = _context.Categories.Where(x => x.IsDeleted == false).ToList();
            return View(categories);
        }


        public ActionResult CreateCategory()
        {

            return View();
        }

        public ActionResult Category(int id)
        {
            Category category = _context.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (category == null)
            {
                return RedirectToAction("Categories");
            }
            return View(category);

        }

        public string SaveCategory()
        {
            var newSubcat = new Category();
            newSubcat.IsDeleted = false;
            newSubcat.CategoryName = Request.Form["CategoryName"].ToString();

            if (Request.Form["Id"].ToString() == "0")
            {
                _context.Categories.Add(newSubcat);
                _context.SaveChanges();
                return newSubcat.Id.ToString();
            }
            else
            {
                int currID = Convert.ToInt32(Request.Form["Id"]);
                var currBanner = _context.Categories.Where(x => x.Id == currID).FirstOrDefault();



                currBanner.CategoryName = newSubcat.CategoryName;
                _context.SaveChanges();
                return currBanner.Id.ToString();
            }
        }

        public string DeleteCategory()
        {

            var ItemID = Convert.ToInt32(Request.Form["ID"]);
            var currBanner = _context.Categories.Where(x => x.Id == ItemID).FirstOrDefault();
            currBanner.IsDeleted = true;
            _context.SaveChanges();
            return "Deleted";
        }
        #endregion

        #region RestaurantCategories
        public ActionResult RestaurantCategories(int id)
        {

            List<RestaurantCategory_VM> restaurantCategories = _context.RestaurantCategories.Where(x => x.RestaurantId == id && x.IsDeleted == false).Select(x => new RestaurantCategory_VM()
            {
                RestaurantId = x.RestaurantId,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.CategoryName,
                RestaurantName = x.Restaurant.RestaurantName,
                Id = x.Id

            }).ToList();


            return View(restaurantCategories);
        }

        public ActionResult SaveRestaurantCategory(int id, int id2)
        {
            var restaurantCategory = new RestaurantCategory();
            restaurantCategory.RestaurantId = id2;
            restaurantCategory.IsDeleted = false;
            restaurantCategory.CategoryId = id;


            if (restaurantCategory.Id == 0)
            {
                _context.RestaurantCategories.Add(restaurantCategory);
                _context.SaveChanges();
                return RedirectToAction(nameof(RestaurantCategories), new { id = id2 });
            }
            else
            {
                int currID = restaurantCategory.Id;
                var currBanner = _context.RestaurantCategories.Where(x => x.Id == currID).FirstOrDefault();


                currBanner.RestaurantId = restaurantCategory.RestaurantId;
                currBanner.CategoryId = restaurantCategory.CategoryId;
                _context.SaveChanges();
                return RedirectToAction(nameof(RestaurantCategories), new { id = currBanner.RestaurantId });
            }
        }

        public string DeleteRestaurantCategory()
        {

            var ItemID = Convert.ToInt32(Request.Form["ID"]);
            var currBanner = _context.RestaurantCategories.Where(x => x.Id == ItemID).FirstOrDefault();
            currBanner.IsDeleted = true;
            _context.SaveChanges();
            return "Deleted";
        }

        public ActionResult AddRestaurantCategory(int id)
        {
            List<Category> categories = _context.Categories.Where(x => x.IsDeleted == false).ToList();
            ViewBag.Restaurant = _context.Restaurants.Where(x => x.Id == id).FirstOrDefault();
            return View(categories);
        }
        #endregion
        #region Events
        public ActionResult Events()
        {
            var events = _context.Events.Where(x => x.IsDeleted == false).ToList();
            return View(events);
        }

        public ActionResult CreateEvent()
        {
            return View();
        }

        public async Task<string> SaveEvent()
        {
            var newSubcat = new Event();
            newSubcat.IsDeleted = false;
            newSubcat.EventName = Request.Form["EventName"].ToString();
            newSubcat.EventDescription = Request.Form["EventDescription"].ToString();
            newSubcat.EventDate = Convert.ToDateTime(Request.Form["EventDate"]);
            var file = Request.Form.Files["EventPhotoUrl"];
            if (file != null)
            {
                var NewFileName = RandomStringNoCharacters(20) + file.FileName.ToString();

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", NewFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                newSubcat.EventPhotoUrl = NewFileName;
            }
            if (Request.Form["Id"].ToString() == "0")
            {
                _context.Events.Add(newSubcat);
                _context.SaveChanges();
                return newSubcat.Id.ToString();
            }
            else
            {
                int currID = Convert.ToInt32(Request.Form["Id"]);
                var currBanner = _context.Events.Where(x => x.Id == currID).FirstOrDefault();
                if (newSubcat.EventPhotoUrl != null)
                {
                    currBanner.EventPhotoUrl = newSubcat.EventPhotoUrl;
                }

                currBanner.EventName = newSubcat.EventName;
                currBanner.EventDescription = newSubcat.EventDescription;
                currBanner.EventDate = newSubcat.EventDate;
                _context.SaveChanges();
                return currBanner.Id.ToString();
            }
        }

        public ActionResult Event(int id)
        {
            Event dbEvent = _context.Events.Where(x => x.Id == id).FirstOrDefault();
            if (dbEvent == null)
            {
                return RedirectToAction("Events");
            }
            return View(dbEvent);

        }

        public string DeleteEvent()
        {

            var ItemID = Convert.ToInt32(Request.Form["ID"]);
            var currBanner = _context.Events.Where(x => x.Id == ItemID).FirstOrDefault();
            currBanner.IsDeleted = true;
            _context.SaveChanges();
            return "Deleted";
        }
        #endregion


        #region Items

        public ActionResult MenuItems(int id)
        {
            var items = _context.Items.Where(x => x.RestaurantCategory.Id == id).ToList();
            ViewBag.RestaurantCategoryId = id;
            return View(items);
        }

        public ActionResult AddMenuItem(int id)
        {
            ViewBag.RestaurantCategory = _context.RestaurantCategories.FirstOrDefault(x => x.Id == id);
            return View();
        }



        public string DeleteMenuItem()
        {

            var ItemID = Convert.ToInt32(Request.Form["ID"]);
            var currBanner = _context.Items.Where(x => x.Id == ItemID).FirstOrDefault();
            currBanner.IsDeleted = true;
            _context.SaveChanges();
            return "Deleted";
        }

        public async Task<string> SaveMenuItem()
        {
            var newSubcat = new Item();
            newSubcat.IsDeleted = false;
            newSubcat.RestaurantCategoryId = Convert.ToInt32(Request.Form["RestaurantCategoryId"]);
            newSubcat.ItemName = Request.Form["ItemName"].ToString();
            newSubcat.Price = Convert.ToInt32(Request.Form["Price"]);
            var file = Request.Form.Files["PhotoUrl"];
            if (file != null)
            {
                var NewFileName = RandomStringNoCharacters(20) + file.FileName.ToString();

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", NewFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                newSubcat.PhotoUrl = NewFileName;
            }
            if (Request.Form["Id"].ToString() == "0")
            {
                _context.Items.Add(newSubcat);
                _context.SaveChanges();
                return newSubcat.Id.ToString();
            }
            else
            {
                int currID = Convert.ToInt32(Request.Form["Id"]);
                var currBanner = _context.Items.Where(x => x.Id == currID).FirstOrDefault();
                if (newSubcat.PhotoUrl != null)
                {
                    currBanner.PhotoUrl = newSubcat.PhotoUrl;
                }

                currBanner.ItemName = newSubcat.ItemName;
                currBanner.Price = newSubcat.Price;
                _context.SaveChanges();
                return currBanner.Id.ToString();
            }
        }

        public ActionResult MenuItem(int id)
        {
            Item menuItem = _context.Items.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
            if (menuItem == null)
            {
                return RedirectToAction("MenuItems");
            }
            return View(menuItem);

        }



        #endregion

        #region QuickOrders

        public ActionResult QuickOrders()
        {
            var quickOrders = _context.QuickOrders.Where(x => x.IsDeleted == false).ToList();
            return View(quickOrders);
        }

        public ActionResult CreateQuickOrder()
        {
            return View();
        }

        public ActionResult QuickOrder(int id)
        {
            QuickOrder quickOrder = _context.QuickOrders.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
            if (quickOrder == null)
            {
                return RedirectToAction("Banners");
            }
            return View(quickOrder);

        }

        public async Task<string> SaveQuickOrder()
        {
            var newSubcat = new QuickOrder();

            newSubcat.IsDeleted = false;
            newSubcat.Price = Convert.ToInt32(Request.Form["Price"]);
            newSubcat.QuickOrderName = Request.Form["QuickOrderName"].ToString();
            var file = Request.Form.Files["PhotoUrl"];
            if (file != null)
            {
                var NewFileName = RandomStringNoCharacters(20) + file.FileName.ToString();

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", NewFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                newSubcat.PhotoUrl = NewFileName;
            }
            if (Request.Form["Id"].ToString() == "0")
            {
                _context.QuickOrders.Add(newSubcat);
                _context.SaveChanges();
                return newSubcat.Id.ToString();
            }
            else
            {
                int currID = Convert.ToInt32(Request.Form["Id"]);
                var currBanner = _context.QuickOrders.Where(x => x.Id == currID).FirstOrDefault();
                if (newSubcat.PhotoUrl != null)
                {
                    currBanner.PhotoUrl = newSubcat.PhotoUrl;
                }

                currBanner.Price = newSubcat.Price;
                currBanner.QuickOrderName = newSubcat.QuickOrderName;
                _context.SaveChanges();
                return currBanner.Id.ToString();
            }
        }

        public string DeleteQuickOrder()
        {

            var ItemID = Convert.ToInt32(Request.Form["ID"]);
            var currBanner = _context.QuickOrders.Where(x => x.Id == ItemID).FirstOrDefault();
            currBanner.IsDeleted = true;
            _context.SaveChanges();
            return "Deleted";
        }


        #endregion

        #region Orders
        public ActionResult Orders()
        {
            var orders = _filter.GetAllOrders();

            return View(orders);
        }

        public ActionResult Order(int id)
        {

            var orderItems = _filter.GetOrderItems(id);
            List<RestaurantOrderItem_VM> restaurantOrderItems = new List<RestaurantOrderItem_VM>();
            CustomOrder_VM customOrder = new CustomOrder_VM();
            PlacedQuickOrder_VM placedQuickOrder = new PlacedQuickOrder_VM();
            foreach (var orderItem in orderItems)
            {
                var restaurantOrder = _filter.GetRestaurantOrder(orderItem.Id);
                if(restaurantOrder != null)
                {
                    var dbRestaurantOrderItems = _filter.GetRestaurantOrderItems(restaurantOrder.Id);
                    foreach (var item in dbRestaurantOrderItems)
                    {
                        restaurantOrderItems.Add(item);
                    }
                  
                }
                var dbCustomOrder = _filter.GetCustomOrder(orderItem.Id);
                if(dbCustomOrder != null)
                {
                    customOrder = dbCustomOrder;
                }
                var dbPlacedQuickOrder = _filter.GetPlacedQuickOrder(orderItem.Id);
                if(dbPlacedQuickOrder != null)
                {
                    placedQuickOrder = dbPlacedQuickOrder;
                }
            }

            ViewBag.restaurantOrderItems = restaurantOrderItems;
            ViewBag.customOrder = customOrder;
            ViewBag.placedQuickOrder = placedQuickOrder;
            return View();
        }

        public async Task<ActionResult> AcceptOrder(int id, int statusId)
        {
            Order_VM ordervm = _filter.GetOrder(id);
            if (ordervm != null)
            {
                ordervm.OrderStatusId = statusId;
                Order order = _unit.Mapper.Map<Order>(ordervm);
                await _unit.OrderRepository.Update(order);
                return RedirectToAction("Orders");
            }

            return RedirectToAction("Orders");
        }

        public async Task<ActionResult> RejectOrder(int id, int statusId)
        {
            Order_VM ordervm = _filter.GetOrder(id);
            if (ordervm != null)
            {
                ordervm.OrderStatusId = statusId;
                Order order = _unit.Mapper.Map<Order>(ordervm);
                await _unit.OrderRepository.Update(order);
                return RedirectToAction("Orders");
            }

            return RedirectToAction("Orders");
        }

        public async Task<ActionResult> SetDeliveryPrice(int id, int price)
        {
            Order_VM ordervm = _filter.GetOrder(id);
            if (ordervm != null)
            {
                ordervm.DeliveryPrice = price;
                Order order = _unit.Mapper.Map<Order>(ordervm);
                await _unit.OrderRepository.Update(order);
                return RedirectToAction("Orders");
            }

            return RedirectToAction("Orders");
        }


        #endregion



        public static string RandomStringNoCharacters(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}