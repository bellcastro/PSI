using Microsoft.EntityFrameworkCore;
using NutriMais.Data;
using NutriMais.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NutriMais.Repositories.Planos
{
    public class PlanoRepository : IPlanoRepositoryInterface
    {
        private readonly NutriMaisContext _context;

        public PlanoRepository(NutriMaisContext context) => _context = context;

        public PlanosModel ObterPlano(string userId)
        {
            PlanosModel plano = _context.PlanosModel             
                .Where(a => a.DataFimPlano < DateTime.Now && a.IdUsuario == userId)
                .OrderBy(a => a.DataInicioPlano).FirstOrDefault();

            return plano;   
        }

        public IEnumerable<PlanosModel> ObterPlanos(string userId)
        {
			IOrderedQueryable<PlanosModel> plano = _context.PlanosModel
                .Where(a => a.IdUsuario == userId)
                .OrderBy(a => a.DataInicioPlano);

            return plano;
        }

        public IEnumerable<PlanoSemanalModel> ObterPlanoSemanal(int idPlano)
        {
            IEnumerable<PlanoSemanalModel> planoSemanal = _context.PlanoSemanalModel               
                .Where(a => a.Id == idPlano)?.ToList();

            return planoSemanal;
        }
        public IEnumerable<PlanoSemanalModel> ObterPlanoSemanal(IEnumerable<int> idsPlano)
        {
            IEnumerable<PlanoSemanalModel> planoSemanal = _context.PlanoSemanalModel               
                .Where(a => idsPlano.Contains(a.IdPlano))?.ToList();

            return planoSemanal;
        }

        public void DeletarPlano(string userId, int idPlano)		
        {
			PlanosModel plano = ObterPlanos(userId)?.FirstOrDefault();

            PlanoSemanalModel planoSemanal = ObterPlanoSemanal(idPlano)?.FirstOrDefault(); 

            _context.Remove(plano);
            _context.Remove(planoSemanal);
            _context.SaveChanges();
        }

        public void AtualizarPlano(PlanoSemanalModel planoSemanal)
        {                  
            _context.Update(planoSemanal);

            _context.SaveChanges();
        }

        public void InserirPlanoUsuario(PlanosModel plano)
		{
            _context.Add(plano);

            _context.SaveChanges();
        }
        public void InserirPlanoSemanal(PlanoSemanalModel planoSemanal)
		{
            _context.Add(planoSemanal);

            _context.SaveChanges();
        }
    }
}
