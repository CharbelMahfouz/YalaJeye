
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.DAL.IRepositories;
using YalaJeye.DAL.Models;

namespace YalaJeye.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly YallaJeyeDBContext _context;

        public GenericRepository(YallaJeyeDBContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            //_context.Set<T>().Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetAllWithPredicate(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public async Task<T> GetById(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public IQueryable<T> GetAllWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = GetAllWithPredicate(predicate);
            var entities = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return entities;
        }

        public  T GetByIdWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = GetAll();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).SingleOrDefault(predicate);
            
        }






    }
}
