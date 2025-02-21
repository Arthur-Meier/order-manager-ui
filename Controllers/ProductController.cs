using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Data;
using OrderManager.Models;

namespace OrderManager.Controllers
{
    public partial class ProductController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;


        public IActionResult Index()
        {
            var produtos = _context.Products.ToList();
            return View(produtos);
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products
                .FirstOrDefault(o => o.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Product product, IFormFile? image) // ⬅️ Permite imagem opcional
        {
            if (image != null && image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    product.Image = memoryStream.ToArray();
                }
            }
            else
            {
                product.Image = null; // ⬅️ Garante que não há problema caso a imagem não seja enviada
            }

            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync(); // ⬅️ Uso de await para operações assíncronas
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
    }
}