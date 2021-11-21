using NutriMais.Models;
using System.Collections.Generic;

namespace NutriMais.Repositories.Receitas
{
	public interface IReceitaRepository
	{
		IEnumerable<ReceitasModel> ObterReceitas(string userId);

		ReceitasModel ObterReceita(string userId, int idReceita);

		void DeletarReceitas(string userId, int idReceita);
	}
}
