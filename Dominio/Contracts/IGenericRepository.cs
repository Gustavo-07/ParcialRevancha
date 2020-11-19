using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dominio.Base;

namespace Dominio.Contracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        
        T Find(int id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void AddRange(List<T> entities);
        void DeleteRange(List<T> entities);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindFirstOrDefault(Expression<Func<T, bool>> predicate);
    }
}