
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.DAL.Models;

namespace YalaJeye.DAL.IRepositories
{
    public interface IRestaurantRepository : IGenericRepository<Restaurant>
    {
        //Task<Restaurant> GetRestaurantById(int id);
        //Task<List<Restaurant>> GetAllRestaurants();
    }
    
}
