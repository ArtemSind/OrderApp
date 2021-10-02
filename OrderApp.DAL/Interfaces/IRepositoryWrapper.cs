using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Interfaces
{
    public interface IRepositoryWrapper
    {
        IOrderRepository Order { get; }
        void Save();
        void Dispose();
    }
}
