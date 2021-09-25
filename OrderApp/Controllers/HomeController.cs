using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderApp.Models;

namespace OrderApp.Controllers
{
    //public class HomeController : Controller
    //{
    //    private ApplicationContext db;
    //    public HomeController(ApplicationContext context)
    //    {
    //        db = context;
    //    }

    //    public async Task<IActionResult> Index()
    //    {
    //        return View(await db.Orders.ToListAsync());
    //    }

    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Create(Order order)
    //    {
    //        db.Orders.Add(order);
    //        await db.SaveChangesAsync();
    //        return RedirectToAction("Index");
    //    }

    //    [HttpGet]
    //    [ActionName("Delete")]
    //    public async Task<IActionResult> ConfirmDelete(int? id)
    //    {
    //        if (id != null)
    //        {
    //            Order order = await db.Orders.FirstOrDefaultAsync(p => p.Id == id);
    //            if (order != null)
    //                return View(order);
    //        }
    //        return NotFound();
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id != null)
    //        {
    //            Order order = await db.Orders.FirstOrDefaultAsync(p => p.Id == id);
    //            if (order != null)
    //            {
    //                db.Orders.Remove(order);
    //                await db.SaveChangesAsync();
    //                return RedirectToAction("Index");
    //            }
    //        }
    //        return NotFound();
    //    }
    //}

    public class HomeController : ControllerBase
    {
        private OrderRepository orderRepository;
        public HomeController(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        
    }
}
