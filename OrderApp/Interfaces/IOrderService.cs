using OrderApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
        OrderDTO GetOrder(int? id);
        IEnumerable<OrderDTO> GetOrders();
        void Dispose();
        void Delete(int? id);
    }
}
