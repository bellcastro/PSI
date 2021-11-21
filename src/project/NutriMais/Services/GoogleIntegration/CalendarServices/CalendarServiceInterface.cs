using NutriMais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Services.GoogleIntegration.CalendarServices
{
    public interface CalendarServiceInterface
    {
        public string GenerateEventLink(AppointmentModel model);
    }
}
