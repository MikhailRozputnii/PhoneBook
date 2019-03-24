using PhoneBook.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PhoneBook.Repositories.Data
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly PhoneBookDbContext _dbContext;

        public BaseRepository(PhoneBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Create(T entity)
        {
            if (entity != null)
                _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity != null)
                _dbContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            if (expression != null)
                return _dbContext.Set<T>().Where(expression);
            return null;
        }

        public T GetUserByCondition(Expression<Func<T, bool>> expression)
        {
            if (expression != null)
                return _dbContext.Set<T>().FirstOrDefault(expression);
            return null;
        }

        public void Update(T entity)
        {
            if (entity != null)
                _dbContext.Set<T>().Update(entity);
        }
    }
}
