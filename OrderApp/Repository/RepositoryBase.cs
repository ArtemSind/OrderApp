using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderApp.Contracts;
using OrderApp.Models;

namespace OrderApp.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
       public RepositoryContext RepositoryContext { get; set; }
       

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<T> GetAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public T Get(int id)
        {
            return RepositoryContext.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
            RepositoryContext.SaveChanges();
        }



        public void Delete(int id)
        {
            T entity = RepositoryContext.Set<T>().Find(id);
            if (entity != null)
                RepositoryContext.Set<T>().Remove(entity);
            RepositoryContext.SaveChanges();
        }
    }
}
