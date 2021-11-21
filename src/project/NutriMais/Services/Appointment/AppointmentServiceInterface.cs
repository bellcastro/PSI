using NutriMais.Models;
using NutriMais.Requests.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Services.Appointment
{
    public interface AppointmentServiceInterface
    {
        public void ConfirmAppointment(AppointmentModel appointment, UserModel user);

        public void RefuseAppointment(AppointmentModel appointment, string reason, UserModel user);

        public void CancelAppointment(AppointmentModel appointment, string reason, UserModel user);

        public void UpdateAppointment(UpdateAppointmentRequest request, AppointmentModel model, UserModel user);

        public void DispatchCheckInEmail(AppointmentModel model);
    }
}
