using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DocOpen.Data
{
    public class DataRepository<T> : IDataRepository<T> where T: class
    {
        protected readonly DocOpenContext _context;
        public DataRepository(DocOpenContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
           return _context.Set<T>().ToList();
        }

        public T GetByIt(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T newEntity)
        {
          _context.Set<T>().Update(newEntity);
        }
    }
}