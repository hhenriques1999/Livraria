using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Carrinho
    {
        [Key]
        public int Id { get; set; }
        public virtual List<ItensCarrinho>? ItensCarrinho { get; set; }
    }
}
