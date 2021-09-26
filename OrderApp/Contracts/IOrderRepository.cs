using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
    }
}
