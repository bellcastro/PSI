using Microsoft.EntityFrameworkCore;
using NutriMais.Data;
using NutriMais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Repositories.Communication
{
    public class CommunicationRepository : CommunicationRepositoryInterface
    {
        private readonly NutriMaisContext _context;

        public CommunicationRepository(NutriMaisContext context)
        {
            _context = context;
        }

        public async Task InsertNewCommunication(UserModel owner, CommunicationModel model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
        }

    }
}
