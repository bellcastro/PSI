using NutriMais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Repositories.User
{
    public interface UserRepositoryInterface
    {
        public Task<List<UserModel>> GetParticipantsFor(UserModel model);
        public Task<UserModel> Find(String id);

        public Task<List<UserModel>> GetAvailablePacients();

        public Task UpdateUser(UserModel model);
    }
}
