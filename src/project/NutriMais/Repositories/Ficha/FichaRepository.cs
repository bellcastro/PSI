using Microsoft.EntityFrameworkCore;
using NutriMais.Data;
using NutriMais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Repositories.Ficha
{
    public class FichaRepository : FichaRepositoryInterface
    {
        private readonly NutriMaisContext _context;
        public FichaRepository(NutriMaisContext context) => _context = context;


        public FichaModel ObterFicha(string userId)
        {
            FichaModel ficha = (FichaModel)_context.FichaModel
                .Include(a => a.Titulo)
                .Include(a => a.Nome)
                .Include(a => a.Email)
                .Where(a => a.IdUsuario == userId);
                

            return ficha;
        }

        public IEnumerable<FichaModel> ObterFichas(int userId)
        {
            IOrderedQueryable<FichaModel> ficha = (IOrderedQueryable<FichaModel>)_context.FichaModel
                .Include(a => a.Titulo)
                .Include(a => a.Nome)
                .Include(a => a.Email)
                .Where(a => a.Id == userId);

            return ficha;
        }

        public async Task InsertNewFicha(UserModel owner, FichaModel model)
        {
            model.IdUsuario = owner.Id;
            _context.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<FichaModel> Find(int id)
        {
            var model = await _context.FichaModel
                .Include(a => a.Titulo)
                .Include(a => a.Nome)
                .Include(a => a.Email)
                .Where(a => a.Id == id)
                .FirstAsync();

            if (model != null)
            {
                return model;
            }

            throw new KeyNotFoundException();
        }

        public async Task UpdateFicha(FichaModel model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FichaModel>> GetConfirmedFichaCloseToStart()
        {
            var ficha = await _context.FichaModel
                .Include(a => a.Titulo)
                .Include(a => a.Nome)
                .Include(a => a.Email)
                .ToListAsync();

            return ficha;
        }

        public Task<List<FichaModel>> GetFichaOf(UserModel owner)
        {
            throw new NotImplementedException();
        }

        public Task<List<FichaModel>> GetConfirmedFichaOf(UserModel owner)
        {
            throw new NotImplementedException();
        }
    }
}
