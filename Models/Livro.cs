using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }

        public string? Autor { get; set; }
        public float Preco { get; set; }
        public string? Capa { get; set; }
        [Display(Name = "Quantidade de Vendas")]
        public int QtdVendas { get; set; }
        public virtual List<Avaliacao>? Avaliacoes { get; set; }
    }
}
