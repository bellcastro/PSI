using Microsoft.EntityFrameworkCore;
using NutriMais.Data;
using NutriMais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Repositories.Appointment
{
    public class AppointmentRepository : AppointmentRepositoryInterface
    {
        private readonly NutriMaisContext _context;

        public AppointmentRepository(NutriMaisContext context)
        {
            _context = context;
        }

        public async Task<List<AppointmentModel>> GetAppointmentsOf(UserModel owner)
        {
            var appointments = await _context.AppointmentModel
                .Include(a => a.Owner)
                .Include(a => a.Participant)
                .Where(a => a.OwnerId == owner.Id || a.ParticipantId == owner.Id)
                .Where(a => a.StartsAt.CompareTo(new DateTime()) == 1)
                .Where(a => a.Status != AppointmentStatus.Refused)
                .ToListAsync();

            return appointments;
        }

        public async Task<List<AppointmentModel>> GetConfirmedAppointmentsOf(UserModel owner)
        {
            var appointments = await _context.AppointmentModel
                .Include(a => a.Owner)
                .Include(a => a.Participant)
                .Where(a => a.OwnerId == owner.Id || a.ParticipantId == owner.Id)
                .Where(a => a.Status == AppointmentStatus.Confirmed)
                .ToListAsync();

            return appointments;
        }

        public async Task InsertNewAppointment(UserModel owner, AppointmentModel model)
        {
            model.OwnerId = owner.Id;
            model.Status = AppointmentStatus.Draft;
            _context.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<AppointmentModel> Find(int id)
        {
            var model = await _context.AppointmentModel
                .Include(a => a.Owner)
                .Include(a => a.Participant)
                .Where(a => a.Id == id)
                .FirstAsync();

            if (model != null)
            {
                return model;
            }

            throw new KeyNotFoundException();
        }

        public async Task UpdateAppointment(AppointmentModel model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AppointmentModel>> GetConfirmedAppointmentsCloseToStart()
        {
            var min = DateTime.Now;
            var max = DateTime.Now.AddHours(24);
            var appointments = await _context.AppointmentModel
                .Include(a => a.Owner)
                .Include(a => a.Participant)
                .Where(a => a.Status == AppointmentStatus.Confirmed)
                .Where(a => a.StartsAt.CompareTo(min) > 0 && a.StartsAt.CompareTo(max) < 0)
                .ToListAsync();

            return appointments;
        }
    }
}
