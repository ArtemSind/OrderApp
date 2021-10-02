using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OrderApp.BLL.DTO;
using OrderApp.BLL.Infrastructure;
using OrderApp.BLL.Interfaces;
using OrderApp.Interfaces;
using OrderApp.Models;
using OrderApp.Repository;

namespace OrderApp.BLL.Services
{
    public class OrderService : IOrderService
    {
        IRepositoryWrapper Database { get; set; }

        public OrderService(IRepositoryWrapper rw)
        {
            Database = rw;
        }
        public void Dispose()
        {
            Database.Dispose();
        }

        public OrderDTO GetOrder(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлен id заказа", "");
            var order = Database.Order.Get(id.Value);
            if (order == null)
                throw new ValidationException("Заказ не найден", "");
            return new OrderDTO
            {
                Date = order.Date,
                FromAdress = order.FromAdress,
                FromCity = order.FromCity,
                ToAdress = order.ToAdress,
                Id = order.Id,
                ToCity = order.ToCity,
                Weight = order.Weight
            };
        }

        public void MakeOrder(OrderDTO orderDto)
        {
            if (orderDto == null)
                throw new ValidationException("Заказ не найден", "");
            Order order = new Order
            {
                Id = orderDto.Id,
                FromAdress = orderDto.FromAdress,
                ToCity = orderDto.ToCity,
                ToAdress = orderDto.ToAdress,
                Weight = orderDto.Weight,
                Date = orderDto.Date
            };
            Database.Order.Create(order);
            Database.Save();
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(Database.Order.GetAll());
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ValidationException("Номер заказа не найден", "");
            Database.Order.Delete(id.Value);
        }
    }
}
