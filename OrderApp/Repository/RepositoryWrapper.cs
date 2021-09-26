using OrderApp.Contracts;
using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext repositoryContext;
        private IOrderRepository order;
        
            
        public IOrderRepository Order
        {
            get
            {
                if (order == null)
                    order = new OrderRepository(repositoryContext);

                return order;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }
        public void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}
