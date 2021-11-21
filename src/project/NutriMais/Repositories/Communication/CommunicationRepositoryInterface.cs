using NutriMais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Repositories.Communication
{
    public interface CommunicationRepositoryInterface
    {
        public Task InsertNewCommunication(UserModel owner, CommunicationModel model);
    }
}
