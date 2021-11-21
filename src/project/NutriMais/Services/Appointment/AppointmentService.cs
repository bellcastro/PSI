using NutriMais.Models;
using NutriMais.Requests.Appointment;
using NutriMais.Services.GoogleIntegration.CalendarServices;
using NutriMais.Services.GoogleIntegration.EmailServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Services.Appointment
{
    public class AppointmentService : AppointmentServiceInterface
    {
        private readonly CalendarServiceInterface _calendarService;
        private readonly EmailServiceInterface _emailService;

        public AppointmentService(CalendarServiceInterface calendarService, EmailServiceInterface emailService)
        {
            _calendarService = calendarService;
            _emailService = emailService;
        }

        public void ConfirmAppointment(AppointmentModel appointment, UserModel user)
        {
            if (appointment.CanRespondToAppointment(user))
            {
                appointment.Status = AppointmentStatus.Confirmed;
                if (appointment.Type == AppointmentType.Virtual)
                {
                    appointment.Link = _calendarService.GenerateEventLink(appointment);
                }
                return;
            }

            throw new UnauthorizedAccessException();

        }

        public void RefuseAppointment(AppointmentModel appointment, string _reason, UserModel user)
        {
            if (appointment.CanRespondToAppointment(user))
            {
                appointment.Status = AppointmentStatus.Refused;
                return;
            }

            throw new UnauthorizedAccessException();

        }

        public void CancelAppointment(AppointmentModel appointment, string _reason, UserModel user)
        {
            if (appointment.CanEditAppointment(user))
            {
                appointment.Status = AppointmentStatus.Cancelled;
                return;
            }

            throw new UnauthorizedAccessException();

        }

        public void UpdateAppointment(UpdateAppointmentRequest request, AppointmentModel model, UserModel user)
        {
            if (model.CanEditAppointment(user))
            {
                if (ShouldResetStatus(model, request))
                {
                    model.Status = AppointmentStatus.Draft;
                }
                model.Title = request.Title;
                model.Description = request.Description;
                model.Type = request.Type;
                model.StartsAt = request.StartsAt;
                model.EndsAt = request.EndsAt;
                
                return;
            }

            throw new UnauthorizedAccessException();
        }

        private bool ShouldResetStatus (AppointmentModel model, UpdateAppointmentRequest request)
        {
            return model.Type != request.Type || !model.StartsAt.Equals(request.StartsAt) || !model.EndsAt.Equals(request.EndsAt);
        }

        public void DispatchCheckInEmail(AppointmentModel model)
        {
            SendEmailInThePerspectiveOf(model, model.Owner);
            SendEmailInThePerspectiveOf(model, model.Participant);
        }

        private void SendEmailInThePerspectiveOf(AppointmentModel model, UserModel user)
        {
            var template = File.ReadAllText("Emails/Appointment/CheckIn.html");
            var body = string.Format(template, user.UserName, model.GetOppositeParticipant(user).FullName, model.StartsAt.ToString("dd/MM/yyyy à\\s HH:mm"));
            _emailService.Send(user.Email, "Consulta se Aproximando", body);
        }
    }
}
