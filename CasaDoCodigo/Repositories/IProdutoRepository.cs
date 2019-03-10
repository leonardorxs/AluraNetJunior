﻿using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories.Interfaces
{
	public interface IProdutoRepository
	{
		Task SaveProdutos(List<Livro> livros);
		Task<IList<Produto>> GetProdutos();
		Task<IList<Produto>> GetProdutos(string nomeProduto);
	}
}