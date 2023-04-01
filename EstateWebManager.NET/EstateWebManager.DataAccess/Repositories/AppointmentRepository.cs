using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models.AppointmentClasses;
using EstateWebManager.Domain.Models.RealEstateClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.DataAccess.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DatabaseContext _databaseContext;

        public AppointmentRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Appointment?> GetByKey(int agentId, int clientId, int realEstateId)
        {
            var appointment = await _databaseContext.Appointments
                .Include(appointment => appointment.Agent)
                .Include(appointment => appointment.Client)
                .Include(appointment => appointment.RealEstate)
                .Where(appointment => appointment.AgentId == agentId
                                      && appointment.ClientId == clientId
                                      && appointment.RealEstateId == realEstateId)
                .SingleOrDefaultAsync();
            return appointment;
        }

        public async Task<List<Appointment>?> GetAll()
        {
            var appointments = await _databaseContext.Appointments
                .Include(appointment => appointment.Agent)
                .Include(appointment => appointment.Client)
                .Include(appointment => appointment.RealEstate)
                .Take(500)
                .ToListAsync();
            return appointments;
        }

        public async Task<List<Appointment>?> GetByDate(DateTime date)
        {
            var appointments = await _databaseContext.Appointments
                .Include(appointment => appointment.Agent)
                .Include(appointment => appointment.Client)
                .Include(appointment => appointment.RealEstate)
                .Where(appointment => appointment.Date == date)
                .ToListAsync();
            return appointments;
        }

        public async Task<List<Appointment>?> GetByAgentId(int agentId)
        {
            var appointments = await _databaseContext.Appointments
                .Include(appointment => appointment.Agent)
                .Include(appointment => appointment.Client)
                .Include(appointment => appointment.RealEstate)
                .Where(appointment => appointment.AgentId == agentId)
                .ToListAsync();
            return appointments;
        }

        public async Task<List<Appointment>?> GetByAgentName(string agentName)
        {
            var appointments = await _databaseContext.Appointments
                .Include(appointment => appointment.Agent)
                .Include(appointment => appointment.Client)
                .Include(appointment => appointment.RealEstate)
                .Where(appointment => appointment.Agent.Name == agentName)
                .ToListAsync();
            return appointments;
        }

        public async Task<List<Appointment>?> GetByClientId(int clientId)
        {
            var appointments = await _databaseContext.Appointments
                .Include(appointment => appointment.Agent)
                .Include(appointment => appointment.Client)
                .Include(appointment => appointment.RealEstate)
                .Where(appointment => appointment.ClientId == clientId)
                .ToListAsync();
            return appointments;
        }

        public async Task<List<Appointment>?> GetByClientName(string clientName)
        {
            var appointments = await _databaseContext.Appointments
                .Include(appointment => appointment.Agent)
                .Include(appointment => appointment.Client)
                .Include(appointment => appointment.RealEstate)
                .Where(appointment => appointment.Client.Name == clientName)
                .ToListAsync();
            return appointments;
        }


        public async Task<List<Appointment>?> GetByRealEstateId(int realEstateId)
        {
            var appointments = await _databaseContext.Appointments
                .Include(appointment => appointment.Agent)
                .Include(appointment => appointment.Client)
                .Include(appointment => appointment.RealEstate)
                .Where(appointment => appointment.RealEstateId == realEstateId)
                .ToListAsync();
            return appointments;
        }


        public async Task<List<Appointment>?> GetByRealEstate(RealEstate realEstate)
        {
            var appointments = await _databaseContext.Appointments
                .Include(appointment => appointment.Agent)
                .Include(appointment => appointment.Client)
                .Include(appointment => appointment.RealEstate)
                .Where(appointment => appointment.RealEstate == realEstate)
                .ToListAsync();
            return appointments;
        }

        public async Task Insert(Appointment appointment)
        {
            await _databaseContext.Appointments.AddAsync(appointment);
        }

        public void Update(Appointment appointment)
        {
            _databaseContext.Appointments.Update(appointment);
        }
        public void Delete(Appointment appointment)
        {
            _databaseContext.Appointments.Remove(appointment);
        }
    }
}
