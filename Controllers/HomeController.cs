using Livraria.Data;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (HttpContext.User.Identity != null)
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var usuario = _context.Users.FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name);
                    if (usuario != null)
                    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        string? idUsuario = usuario?.Id;
                        bool? vendedor = usuario.Vendedor;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                        ViewData["IdUsuario"] = idUsuario;
                    }
                }
            }

			ViewData["LivrosMaisVendidos"] = _context.Livros.OrderByDescending(p => p.QtdVendas).Take(5).ToList();
            ViewData["MelhoresAvaliados"] = _context.Livros.Include(p => p.Avaliacoes).OrderByDescending(p => p.Avaliacoes.Average(a => a.Estrelas)).ToList();

			return View();
        }

        public IActionResult SobreNos()
        {
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