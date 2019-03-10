using CasaDoCodigo.Models;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories.Interfaces
{
	public interface ICategoriaRepository
	{
		Task<Categoria> AddCategoria(string nomeCategoria);
	}
}
