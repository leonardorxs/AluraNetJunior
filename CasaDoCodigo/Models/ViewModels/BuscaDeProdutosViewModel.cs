using System.Collections.Generic;

namespace CasaDoCodigo.Models.ViewModels
{
	public class BuscaDeProdutosViewModel
	{
		public IList<Produto> Produtos { get; set; }
		public string Pesquisa { get; set; }
	}
}
