using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
	public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
	{
		private readonly ICategoriaRepository categoriaRepository;

		public ProdutoRepository(ApplicationContext contexto, ICategoriaRepository categoriaRepository) : base(contexto)
		{
			this.categoriaRepository = categoriaRepository;
		}

		public async Task<IList<Produto>> GetProdutos()
		{

			return await dbSet.Include(p => p.Categoria).ToListAsync();
		}

		public async Task<IList<Produto>> GetProdutos(string nomeProduto)
		{
			return await dbSet.Include(p => p.Categoria).Where(p => p.Nome.Contains(nomeProduto)).ToListAsync();
		}

		public async Task SaveProdutos(List<Livro> livros)
		{
			foreach (var livro in livros)
			{
				if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
				{
					var categoria = await categoriaRepository.AddCategoria(livro.Categoria);
					dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco, categoria));
				}
			}
			await contexto.SaveChangesAsync();
		}
	}
}
