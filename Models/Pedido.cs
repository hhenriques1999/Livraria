using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public string? IdUsuario { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }
        public virtual List<Livro>? Livros { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario? Usuario { get; set; }
    }
}
