using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderApp.Models;
using OrderApp.Repository;

namespace OrderApp.Controllers
{
    public class HomeController : Controller
    {
        private IRepository or;
        public HomeController(IRepository context)
        {
            or = context;
        }

        public  IActionResult Index()
        {
            return View(or.GetAll().ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Create(Order order)
        {
            or.Create(order);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Order order = or.GetAll().FirstOrDefault(p => p.Id == id); 
                if (order != null)
                    return View(order);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Order order = or.GetAll().FirstOrDefault(p => p.Id == id); 
                if (order != null)
                {
                    or.Delete(id.Value);
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
