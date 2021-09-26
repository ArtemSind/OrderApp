using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Contracts
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);

        void Delete(int id);
    }
}
