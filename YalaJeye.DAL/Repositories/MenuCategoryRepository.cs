
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
    public class MenuCategoryRepository : GenericRepository<RestaurantCategory> , IMenuCategoryRepository
    {
        


        public MenuCategoryRepository(YallaJeyeDBContext context) : base(context)
        {
          
        }

        //public async Task<List<RestaurantCategory>> GetByRestaurantId(int id) {
        //    var categories = await _context.RestaurantCategory.Include(i=> i.Category).Include(i=> i.Restaurant).Where(x => x.RestaurantId == id).ToListAsync();
        //    return categories;
        //}
    }
}
