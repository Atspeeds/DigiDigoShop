using _0_FrameWork.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _0_FrameWork.Infrastrure
{
    public class RepositoryBase<TKey, T> : IRepositoryBase<TKey, T> where T : class
    {
        private DbContext DbContext;

        public RepositoryBase(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Create(T entity)
        {
            DbContext.Add(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().Any(expression);
        }

        public T Get(TKey key)
        {
            return DbContext.Set<T>().Find(key);
        }

        public IEnumerable<T> Get()
        {
            return DbContext.Set<T>().ToList();
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

    }
}
