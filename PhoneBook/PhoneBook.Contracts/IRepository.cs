using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PhoneBook.Contracts
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
