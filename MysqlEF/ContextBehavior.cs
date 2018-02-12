using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MysqlEF
{
    public class ContextBehavior : IDisposable
    {
        private ProductDbContext _context = new ProductDbContext();

        public ContextBehavior()
        {
            _context.Database.EnsureCreated();
        }

        public void Add<T>(T item) where T : class
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public IQueryable<T> Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var data = _context.Set<T>().Where(predicate);
            List<T> dataList = data.ToList();
            foreach (var item in data)
            {
                _context.Set<T>().Remove(item);
            }
            _context.SaveChanges();
            return data;
        }

        public void Delete<T>(T item) where T : class
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public void Update<T>(T item) where T : class
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<User> GetUserWithProducts()
        {
            return _context.Users.Include(x => x.Products);
        }

        public void Dispose()
        {
        }
    }
}
