using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dominio.Base;
using Dominio.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructura.Base
{
    public abstract class GenericRepository<T>: IGenericRepository<T>  where T : BaseEntity
    {
        protected IDbContext Db;
        protected readonly DbSet<T> Dbset;
        
        protected GenericRepository(IDbContext context)
        {
            Db = context;
            Dbset = context.Set<T>();
        }
        
        public T Find(int id)
        {
            return Dbset.Find(id);
        }

        public void Add(T entity)
        {
            Dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            Dbset.Remove(entity);
        }

        public void Edit(T entity)
        {
            Dbset.Update(entity);
        }

        public void AddRange(List<T> entities)
        {
            Dbset.AddRange(entities);
        }

        public void DeleteRange(List<T> entities)
        {
            Dbset.RemoveRange(entities);
        }

        public IEnumerable<T> GetAll()
        {
            return Dbset.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return Dbset.Where(predicate).AsEnumerable();
        }

        public T FindFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Dbset.FirstOrDefault(predicate);
        }
    }
}