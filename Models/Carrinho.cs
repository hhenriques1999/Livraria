using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Models
{
	public class Carrinho
	{
		[Key]
		public int Id { get; set; }
		public virtual List<Livro>? Livros { get; set; }

		public string LivrosIds { get; set; }

		public string IdUsuario { get; set; }

		[ForeignKey(nameof(IdUsuario))]
		public virtual Usuario Usuario { get; set; }
	}
}
