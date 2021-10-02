using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderApp.Models;
using OrderApp.Repository;
using OrderApp.Interfaces;
using OrderApp.BLL.Interfaces;
using OrderApp.BLL.DTO;
using OrderApp.BLL.Infrastructure;
using System.Collections.Generic;
using AutoMapper;

namespace OrderApp.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }

        public  IActionResult Index()
        {
            IEnumerable<OrderDTO> orderDTOs = orderService.GetOrders();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<OrderDTO>, List<OrderViewModel>>(orderDTOs);
            return View(orders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Create(OrderViewModel order)
        {
            try
            {
                var orderDto = new OrderDTO
                {
                    Date = order.Date,
                    FromAdress = order.FromAdress,
                    FromCity = order.FromCity,
                    Id = order.Id,
                    ToAdress = order.ToAdress,
                    ToCity = order.ToCity,
                    Weight = order.Weight
                };
                orderService.MakeOrder(orderDto);
            }
            catch (ValidationException ex)
            {

                ModelState.AddModelError(ex.Property, ex.Message);
            }
            
            return RedirectToAction("Index");
        }

        

        [HttpGet]
        public IActionResult Delete(int id)
        {
            orderService.Delete(id);
            return RedirectToAction("Index");
           
        }
    }
}
