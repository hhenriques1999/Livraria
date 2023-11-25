using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }
        public int Estrelas { get; set; }
        public string? Comentario { get; set; }
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario? Avaliador { get; set; }
        [ForeignKey("IdLivro")]
        public virtual Livro? Livro { get; set; }
    }
}
