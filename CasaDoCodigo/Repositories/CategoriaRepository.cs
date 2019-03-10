using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
	public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
	{
		public CategoriaRepository(ApplicationContext contexto)
			: base(contexto)
		{
		}

		public async Task<Categoria> AddCategoria(string nomeCategoria)
		{
			var categoria = dbSet.Where(c => c.Nome == nomeCategoria).SingleOrDefault();

			if (categoria == null)
			{
				var novaCategoria = new Categoria()
				{
					Nome = nomeCategoria
				};

				categoria = dbSet.Add(novaCategoria).Entity;
				await contexto.SaveChangesAsync();
			}

			return categoria;
		}
	}
}
