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
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
       
        public RestaurantRepository(YallaJeyeDBContext context) : base(context)
        {
           
        }

       //public async Task<List<Restaurant>> GetAllRestaurants()
       // {
       //     return await _context.Restaurant.Include(i => i.City).ToListAsync();
       // }
       // public async Task<Restaurant> GetRestaurantById(int id)
       // {
       //     return await _context.Restaurant.Include(i => i.City).FirstOrDefaultAsync(i => i.Id == id);
        //}
    }
}
