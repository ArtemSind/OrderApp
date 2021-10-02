using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderApp.Models;
using OrderApp.Repository;
using OrderApp.Interfaces;
using OrderApp.BLL.Interfaces;

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
            return View(orderService.GetOrders());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Create(Order order)
        {
            orderService.MakeOrder()
            rw.Order.Create(order);
            return RedirectToAction("Index");
        }

        

        [HttpGet]
        public IActionResult Delete(int id)
        {
            rw.Order.Delete(id);
            return RedirectToAction("Index");
           
        }
    }
}
