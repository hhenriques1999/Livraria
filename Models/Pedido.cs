using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCarrinho { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }
        public virtual Carrinho? Carrinho { get; set; }
        public virtual List<Livro>? Livros { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario? Usuario { get; set; }
    }
}
