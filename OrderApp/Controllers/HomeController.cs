using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderApp.Models;
using OrderApp.Repository;
using OrderApp.Contracts;

namespace OrderApp.Controllers
{
    public class HomeController : Controller
    {
        private IRepositoryWrapper rw;
        public HomeController(IRepositoryWrapper repositoryWrapper)
        {
            rw = repositoryWrapper;
        }

        public  IActionResult Index()
        {
            return View(rw.Order.GetAll().ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Create(Order order)
        {
            rw.Order.Create(order);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Order order = rw.Order.GetAll().FirstOrDefault(p => p.Id == id); 
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
                Order order = rw.Order.GetAll().FirstOrDefault(p => p.Id == id); 
                if (order != null)
                {
                    rw.Order.Delete(id.Value);
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
