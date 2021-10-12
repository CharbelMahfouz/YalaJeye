using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YalaJeye.DAL.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task Update(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllWithPredicate(Expression<Func<T, bool>> predicate);
        Task<T> GetById(int Id);
        IQueryable<T> GetAllWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        T GetByIdWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    }
}
