using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public virtual List<ItensCarrinho> ItensCarrinho { get; set; }
        public virtual List<Avaliacao> Avaliacoes { get; set; }
    }
}
