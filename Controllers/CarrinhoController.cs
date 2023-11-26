using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Livraria.Data;
using Livraria.Models;

namespace Livraria.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly LivrariaDbContext _context;

        public CarrinhoController(LivrariaDbContext context)
        {
            _context = context;
        }

        // GET: Carrinho
        public async Task<IActionResult> Index()
        {
            var livrariaDbContext = _context.Carrinho.Include(c => c.Usuario);
            return View(await livrariaDbContext.ToListAsync());
        }

        // GET: Carrinho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carrinho == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinho
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrinho == null)
            {
                return NotFound();
            }

            return View(carrinho);
        }

        // GET: Carrinho/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Carrinho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LivrosIds,IdUsuario")] Carrinho carrinho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrinho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", carrinho.IdUsuario);
            return View(carrinho);
        }

        // GET: Carrinho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carrinho == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinho.FindAsync(id);
            if (carrinho == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", carrinho.IdUsuario);
            return View(carrinho);
        }

        // POST: Carrinho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LivrosIds,IdUsuario")] Carrinho carrinho)
        {
            if (id != carrinho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrinho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrinhoExists(carrinho.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", carrinho.IdUsuario);
            return View(carrinho);
        }

        // GET: Carrinho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carrinho == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinho
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrinho == null)
            {
                return NotFound();
            }

            return View(carrinho);
        }

        // POST: Carrinho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carrinho == null)
            {
                return Problem("Entity set 'LivrariaDbContext.Carrinho'  is null.");
            }
            var carrinho = await _context.Carrinho.FindAsync(id);
            if (carrinho != null)
            {
                _context.Carrinho.Remove(carrinho);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrinhoExists(int id)
        {
          return (_context.Carrinho?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
