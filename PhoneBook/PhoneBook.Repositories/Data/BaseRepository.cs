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
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
