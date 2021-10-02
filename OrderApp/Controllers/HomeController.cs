using System.Linq;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index(SortState sortOrder = SortState.IdDesc)
        {
            IEnumerable<OrderDTO> orderDTOs = orderService.GetOrders();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<OrderDTO>, List<OrderViewModel>>(orderDTOs);

            ViewData["IdSort"] = sortOrder == SortState.IdDesc ? SortState.IdAsc : SortState.IdDesc;
            ViewData["FromCitySort"] = sortOrder == SortState.FromCityDesc ? SortState.FromCityAsc : SortState.FromCityDesc;
            ViewData["FromAdressSort"] = sortOrder == SortState.FromAdressDesc ? SortState.FromAdressAsc : SortState.FromAdressDesc;
            ViewData["ToCitySort"] = sortOrder == SortState.ToCityDesc ? SortState.ToCityAsc : SortState.ToCityDesc;
            ViewData["ToAdressSort"] = sortOrder == SortState.ToAdressDesc ? SortState.ToAdressAsc : SortState.ToAdressDesc;
            ViewData["WeightSort"] = sortOrder == SortState.WeightDesc ? SortState.WeightAsc : SortState.WeightDesc;
            ViewData["DateSort"] = sortOrder == SortState.DateDesc ? SortState.DateAsc : SortState.DateDesc;


            orders = sortOrder switch
            {
                SortState.IdAsc => orders.OrderBy(s => s.Id).ToList(),
                SortState.FromCityAsc => orders.OrderBy(s => s.FromCity).ToList(),
                SortState.FromCityDesc => orders.OrderByDescending(s => s.FromCity).ToList(),
                SortState.FromAdressAsc => orders.OrderBy(s => s.FromAdress).ToList(),
                SortState.FromAdressDesc => orders.OrderByDescending(s => s.FromAdress).ToList(),
                SortState.ToCityAsc => orders.OrderBy(s => s.ToCity).ToList(),
                SortState.ToCityDesc => orders.OrderByDescending(s => s.ToCity).ToList(),
                SortState.ToAdressAsc => orders.OrderBy(s => s.ToAdress).ToList(),
                SortState.ToAdressDesc => orders.OrderByDescending(s => s.ToAdress).ToList(),
                SortState.WeightAsc => orders.OrderBy(s => s.Weight).ToList(),
                SortState.WeightDesc => orders.OrderByDescending(s => s.Weight).ToList(),
                SortState.DateAsc => orders.OrderBy(s => s.Date).ToList(),
                SortState.DateDesc => orders.OrderByDescending(s => s.Date).ToList(),
                _ => orders.OrderByDescending(s => s.Id).ToList()
            };
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
