using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _0_FrameWork.Domain
{
    public interface IRepositoryBase<TKey, T> where T : class
    {
        void Create(T entity);
        T Get(TKey key);
        IEnumerable<T> Get();
        bool Exists(Expression<Func<T, bool>> expression);
        public void Save();
    }
}
