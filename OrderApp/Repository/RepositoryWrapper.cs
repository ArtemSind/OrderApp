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
                return order;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext, IOrderRepository orderRepository)
        {
            this.repositoryContext = repositoryContext;
            order = orderRepository;
        }
        public void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}
