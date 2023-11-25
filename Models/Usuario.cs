using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public virtual List<Pedido>? Pedidos { get; set; }
        public virtual List<Avaliacao>? Avaliacoes { get; set; }
    }
}
