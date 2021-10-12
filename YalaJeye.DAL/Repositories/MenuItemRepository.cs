
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.DAL.IRepositories;
using YalaJeye.DAL.Models;

namespace YalaJeye.DAL.Repositories
{
    public class MenuItemRepository : GenericRepository<Item>, IMenuItemRepository
    {
        private readonly YallaJeyeDBContext _context;
        public MenuItemRepository(YallaJeyeDBContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<Item> GetItemById(int id)
        //{
        //    return await _context.Item.Include(i => i.RestaurantCategory).FirstOrDefaultAsync(x => x.Id == id);
        //}

        public  List<Item> GetByCategory(int id)
        {
            var category =  _context.RestaurantCategories.Where(x => x.Id == id).Include(i=> i.Category).FirstOrDefault();
            if(category.Category.CategoryName == "All")
            {
                return  _context.Items.Include(i=> i.RestaurantCategory).Where(x => x.RestaurantCategory.Restaurant.Id == category.Restaurant.Id && x.IsDeleted == false).ToList();
            }
            
            return  _context.Items.Include(i => i.RestaurantCategory).Where(x => x.RestaurantCategoryId == id && x.IsDeleted == false).ToList();
        }
    }
}
