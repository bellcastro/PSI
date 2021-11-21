using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NutriMais.Data;
using NutriMais.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Repositories.User
{
    public class UserRepository : UserRepositoryInterface
    {
        private readonly NutriMaisContext _context;

        public UserRepository(NutriMaisContext context)
        {
            _context = context;
        }

        public async Task<UserModel> Find(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                return (UserModel) user;
            }

            throw new KeyNotFoundException();
        }

        public async Task<List<UserModel>> GetAvailablePacients()
        {
            var users = await _context.Users.ToListAsync();
            return users.Cast<UserModel>().Where(u => u.IsAvailable).ToList();
        }

        public async Task<List<UserModel>> GetParticipantsFor(UserModel model)
        {
            if (!model.ENutricionista && model.NutricionistaId != null) 
            {
                var nutricionistas = new List<UserModel>();
                nutricionistas.Add(await Find(model.NutricionistaId));
                return nutricionistas;
            }
            var users = await _context.Users.ToListAsync();
            return users.Cast<UserModel>().Where(u => u.NutricionistaId == model.Id).ToList();
        }

        public async Task UpdateUser(UserModel model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
