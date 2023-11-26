using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Livraria.Data;
using Livraria.Models;
using System.Security.Claims;

namespace Livraria.Controllers
{
	public class LivrosController : Controller
	{
		private readonly LivrariaDbContext _context;

		public LivrosController(LivrariaDbContext context)
		{
			_context = context;
		}

		// GET: Livros
		public async Task<IActionResult> Index()
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
						ViewData["Vendedor"] = vendedor;
					}
				}
			}

			return _context.Livros != null ?
						View(await _context.Livros.ToListAsync()) :
						Problem("Entity set 'LivrariaDbContext.Livros'  is null.");
		}

		public async Task<IActionResult> MaisVendidos()
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
						ViewData["Vendedor"] = vendedor;
					}
				}
			}

			return _context.Livros != null ?
						View(await _context.Livros.OrderByDescending(l => l.QtdVendas).Take(10).ToListAsync()) :
						Problem("Entity set 'LivrariaDbContext.Livros'  is null.");
		}

		// GET: Livros/Details/5
		public async Task<IActionResult> Details(int? id)
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
						ViewData["Vendedor"] = vendedor;
					}
					
				}
			}

			if (id == null || _context.Livros == null)
			{
				return NotFound();
			}

			var livro = await _context.Livros
				.FirstOrDefaultAsync(m => m.Id == id);

			if (livro == null)
			{
				return NotFound();
			}

			var avaliacoesLivro = _context.Avaliacao.Where(a => a.IdLivro == livro.Id).ToList();

			foreach (var avaliacao in avaliacoesLivro)
			{
				if (!string.IsNullOrEmpty(avaliacao.IdUsuario))
				{
					avaliacao.Avaliador = _context.Users.FirstOrDefault(u => u.Id == avaliacao.IdUsuario);
				}
			}

			livro.Avaliacoes = avaliacoesLivro;

			return View(livro);
		}

		// GET: Livros/Create
		public IActionResult Create()
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
						ViewData["Vendedor"] = vendedor;
					}
				}
			}

			return View();
		}

		// POST: Livros/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Nome,Autor,Preco,Capa,QtdVendas")] Livro livro)
		{
			if (ModelState.IsValid)
			{
				_context.Add(livro);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(livro);
		}

		// GET: Livros/Edit/5
		public async Task<IActionResult> Edit(int? id)
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
						ViewData["Vendedor"] = vendedor;
					}
				}
			}

			if (id == null || _context.Livros == null)
			{
				return NotFound();
			}

			var livro = await _context.Livros.FindAsync(id);
			if (livro == null)
			{
				return NotFound();
			}
			return View(livro);
		}

		// POST: Livros/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Autor,Preco,Capa,QtdVendas")] Livro livro)
		{
			var livroVelho = _context.Livros.AsNoTracking().First(p => p.Id == id);

			if (string.IsNullOrEmpty(livro.Capa))
			{
				livro.Capa = livroVelho.Capa;
			}

			if (id != livro.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(livro);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!LivroExists(livro.Id))
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
			return View(livro);
		}

		[HttpPost("/Livros/AdicionarAvaliacao/{id}")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AdicionarAvaliacao(int? id, [Bind("Estrelas, Comentario, IdUsuario, IdLivro")] Avaliacao avaliacao)
		{
			if (id == null || avaliacao == null)
			{
				if (string.IsNullOrEmpty(avaliacao?.IdUsuario))
				{
					return NotFound();
				}
				return NotFound();
			}

			var livro = await _context.Livros.FirstOrDefaultAsync(m => m.Id == id);

			if (livro == null)
			{
				return NotFound();
			}
			else
			{
				if (ModelState.IsValid)
				{
					if (livro.Avaliacoes != null)
					{
						livro.Avaliacoes.Add(avaliacao);
						await _context.SaveChangesAsync();
						return RedirectToAction(nameof(Details), new { id });
					}
					else
					{
						livro.Avaliacoes = new List<Avaliacao> { avaliacao };
						await _context.SaveChangesAsync();
						return RedirectToAction(nameof(Details), new { id });
					}
				}
				else
				{
					throw new InvalidOperationException("Model state is invalid");
				}
			}

			return NotFound();
		}

		// GET: Livros/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Livros == null)
			{
				return NotFound();
			}

			var livro = await _context.Livros
				.FirstOrDefaultAsync(m => m.Id == id);
			if (livro == null)
			{
				return NotFound();
			}

			return View(livro);
		}

		// POST: Livros/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Livros == null)
			{
				return Problem("Entity set 'LivrariaDbContext.Livros'  is null.");
			}
			var livro = await _context.Livros.FindAsync(id);
			if (livro != null)
			{
				_context.Livros.Remove(livro);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool LivroExists(int id)
		{
			return (_context.Livros?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
