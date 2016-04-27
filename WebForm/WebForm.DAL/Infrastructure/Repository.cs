using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using WebForm.Data;
using WebForm.DAL.Infrastructure;
using System.Data.Entity;

namespace WebForm.DAL
{
    public abstract class Repository<T> where T : class
    {
        protected ApplicationDbContext dataContext;
        private readonly DbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected ApplicationDbContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        protected Repository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        public virtual IQueryable<T> Source => dbSet;

        public T Add(T item)
        {
            dbSet.Add(item);
            //dataContext.SaveChanges();

            return item;
        }

        //public T Get(object id)
        //{
        //    return _context.Set<T>().Load(id);
        //}

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.AsQueryable().FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return dbSet.AsQueryable().Where(predicate);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
            //dataContext.SaveChanges();
        }

        public void Update(T item)
        {
            dataContext.Entry(item).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
            //dataContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            //dataContext.SaveChanges();
        }
    }
}