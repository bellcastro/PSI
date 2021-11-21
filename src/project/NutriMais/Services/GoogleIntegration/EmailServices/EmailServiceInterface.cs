using NutriMais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Services.GoogleIntegration.EmailServices
{
    public interface EmailServiceInterface
    {
        public void Send(string to, string subject, string body);
    }
}
