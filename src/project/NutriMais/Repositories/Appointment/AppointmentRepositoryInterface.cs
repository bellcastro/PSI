using NutriMais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Repositories.Appointment
{
    public interface AppointmentRepositoryInterface
    {
        public Task InsertNewAppointment(UserModel owner, AppointmentModel model);

        public Task<List<AppointmentModel>> GetAppointmentsOf(UserModel owner);

        public Task<List<AppointmentModel>> GetConfirmedAppointmentsOf(UserModel owner);

        public Task<AppointmentModel> Find(int id);

        public Task UpdateAppointment(AppointmentModel model);

        public Task<List<AppointmentModel>> GetConfirmedAppointmentsCloseToStart();
    }
}
