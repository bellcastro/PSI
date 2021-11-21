using NutriMais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Repositories.Ficha
{
    interface FichaRepositoryInterface
    {
        FichaModel ObterFicha(string userId);
        IEnumerable<FichaModel> ObterFichas(int userId);

        public Task<List<FichaModel>> GetConfirmedFichaOf(UserModel owner);

        public Task<FichaModel> Find(int id);

        public Task UpdateFicha(FichaModel model);

        public Task<List<FichaModel>> GetConfirmedFichaCloseToStart();
    }
}
