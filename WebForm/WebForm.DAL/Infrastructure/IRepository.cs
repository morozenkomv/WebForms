using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace WebForm.DAL
{
    public interface IRepository<T> where T : class, new()
    {
        IQueryable<T> Source { get; }
        //T Get(object id);

        T Get(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);

        void Update(T entity);

        T Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
