using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Models
{
	public class Categoria : BaseModel
	{
		[Required]
		public string Nome { get; set; }
	}
}
