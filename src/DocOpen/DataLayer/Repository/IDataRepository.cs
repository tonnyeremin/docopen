using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DocOpen.Data
{
    public interface IDataRepository<T> where T : class
    {
         IEnumerable<T> GetAll();
         T GetByIt(int id);
         IEnumerable<T> Find(Expression<Func<T, bool>> expression);
         void Add(T entity);
         void Update(T newEntity);
         void Remove(T entity);

    }
}