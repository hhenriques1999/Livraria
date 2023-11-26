using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Usuario : IdentityUser
    {
        [Key]
        public string? Nome { get; set; }
        public virtual List<Pedido>? Pedidos { get; set; }
        public virtual List<Avaliacao>? Avaliacoes { get; set; }
        public bool Vendedor { get; set; }
    }
}
