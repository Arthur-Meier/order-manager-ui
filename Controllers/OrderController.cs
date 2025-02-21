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

        [HttpGet("orders")]
        public IActionResult Index(int? clientId, DateTime? startDate, DateTime? endDate)
        {
            // Certificando-se de que a lista de clientes seja exibida
            ViewBag.Clients = _context.Clients.ToList();

            // Certificando-se de que as datas sejam convertidas para UTC
            DateTime? startDateUtc = startDate?.ToUniversalTime();
            DateTime? endDateUtc = endDate?.ToUniversalTime();

            // Armazena os filtros na ViewBag para reaplicá-los na View
            ViewBag.SelectedClientId = clientId;
            ViewBag.SelectedStartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.SelectedEndDate = endDate?.ToString("yyyy-MM-dd");

            var orders = _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Items)
                .AsQueryable();

            if (clientId.HasValue)
                orders = orders.Where(o => o.Client.Id == clientId);

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
