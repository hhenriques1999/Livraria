using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class ItensCarrinho
    {
        [Key]
        public int Id { get; set; }
        public int IdLivro { get; set; }
        public int IdCarrinho { get; set; }
        [ForeignKey("IdLivro")]
        public virtual Livro? Livro { get; set; }
        [ForeignKey("IdCarrinho")]
        public virtual Carrinho? Carrinho { get; set; }
    }
}
