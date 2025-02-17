using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManager.Data;
using OrderManager.Models;
using System.Linq;

namespace OrderManager.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string clientName, DateTime? startDate, DateTime? endDate)
        {
            // Certificando-se de que as datas sejam convertidas para UTC
            DateTime? startDateUtc = startDate?.ToUniversalTime();
            DateTime? endDateUtc = endDate?.ToUniversalTime();

            var orders = _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Items)
                .AsQueryable();

            if (!string.IsNullOrEmpty(clientName))
                orders = orders.Where(o => o.Client.Name.Contains(clientName));

            if (startDateUtc.HasValue)
                orders = orders.Where(o => o.OrderDate >= startDateUtc.Value);

            if (endDateUtc.HasValue)
                orders = orders.Where(o => o.OrderDate <= endDateUtc.Value);

            return View(orders.ToList());
        }


        public IActionResult Create()
        {
            ViewBag.Clients = _context.Clients.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            order.OrderDate = order.OrderDate.ToUniversalTime();
            order.TotalValue = order.Items.Sum(item => item.Total);
            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        
            // ViewBag.Clients = _context.Clients.ToList();
            // return View(order);
        }

        public IActionResult Details(int id)
        {
            var order = _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Items)
                .FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }
    }
}
