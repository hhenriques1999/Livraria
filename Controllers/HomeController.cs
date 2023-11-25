using Livraria.Data;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Livraria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LivrariaDbContext _context;

        public HomeController(ILogger<HomeController> logger, LivrariaDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["LivrosMaisVendidos"] = _context.Livros.OrderBy(p => p.QtdVendas).Take(5).ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}