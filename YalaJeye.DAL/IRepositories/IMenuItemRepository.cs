
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.DAL.Models;

namespace YalaJeye.DAL.IRepositories
{
    public interface IMenuItemRepository : IGenericRepository<Item>
    {
        List<Item> GetByCategory(int id);
        //Task<Item> GetItemById(int id);
    }
}
