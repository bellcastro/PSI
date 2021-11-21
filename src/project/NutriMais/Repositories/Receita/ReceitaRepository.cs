using NutriMais.Data;
using NutriMais.Models;
using System.Collections.Generic;
using System.Linq;

namespace NutriMais.Repositories.Receitas
{
	public class ReceitaRepository : IReceitaRepository
    {
        private readonly NutriMaisContext _context;

        public ReceitaRepository(NutriMaisContext context) => _context = context;

        public IEnumerable<ReceitasModel> ObterReceitas(string userId)
        {
			IQueryable<ReceitasModel> receitas = _context.ReceitasModel               
                .Where(a => a.IdUsuario == userId);

            return receitas;
        }
        
        public ReceitasModel ObterReceita(string userId, int idReceita)
		{
			ReceitasModel receita = _context.ReceitasModel                
                .Where(a => a.IdUsuario == userId && a.Id == idReceita)?.FirstOrDefault();

            return receita;
        }

        public void DeletarReceitas(string userId, int idReceita)
		{
			ReceitasModel receitas = ObterReceita(userId, idReceita);

            _context.Remove(receitas);
        }
    }
}
