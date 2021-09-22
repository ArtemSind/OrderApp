using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderApp.Models;

namespace OrderApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Orders.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
