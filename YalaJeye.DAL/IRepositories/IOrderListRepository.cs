﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.DAL.Models;

namespace YalaJeye.DAL.IRepositories
{
   public interface IOrderListRepository : IGenericRepository<OrderList>
    {
        Task<OrderList> CreateOrderList(int customerId);
    }
}
