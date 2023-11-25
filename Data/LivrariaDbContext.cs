using Livraria.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Data
{
    public class LivrariaDbContext : DbContext
    {
        public LivrariaDbContext(DbContextOptions<LivrariaDbContext> options) : base(options) { }
        public DbSet<Livro> Livros { get; set; }
    }

}
