using NutriMais.Models;
using System.Collections.Generic;

namespace NutriMais.Repositories.Planos
{
	public interface IPlanoRepositoryInterface
	{
		PlanosModel ObterPlano(string userId);
		IEnumerable<PlanosModel> ObterPlanos(string userId);
		IEnumerable<PlanoSemanalModel> ObterPlanoSemanal(int idPlano);
		IEnumerable<PlanoSemanalModel> ObterPlanoSemanal(IEnumerable<int> idsPlano);
		void DeletarPlano(string userId, int idPlano);
		void AtualizarPlano(PlanoSemanalModel planoSemanal);
		void InserirPlanoUsuario(PlanosModel plano);
		void InserirPlanoSemanal(PlanoSemanalModel planoSemanal);
	}
}
