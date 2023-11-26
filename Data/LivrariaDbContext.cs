using Livraria.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Data
{
    public class LivrariaDbContext : IdentityDbContext<Usuario>
    {
        public LivrariaDbContext(DbContextOptions<LivrariaDbContext> options) : base(options) { }
        public DbSet<Livro> Livros { get; set; }
    }

}
