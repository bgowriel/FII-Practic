using EstateWebManager.Domain.Models.AppointmentClasses;
using EstateWebManager.Domain.Models.RealEstateClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Abstractions
{
    public interface IAppointmentRepository
    {
        Task<Appointment?> GetByKey(int agentId, int clientId, int realEstateId);
        Task<List<Appointment>?> GetAll();
        Task<List<Appointment>?> GetByDate(DateTime date);
        Task<List<Appointment>?> GetByAgentId(int agentId);
        Task<List<Appointment>?> GetByAgentName(string agentName);
        Task<List<Appointment>?> GetByClientId(int clientId);
        Task<List<Appointment>?> GetByClientName(string clientName);
        Task<List<Appointment>?> GetByRealEstateId(int realEstateId);
        Task<List<Appointment>?> GetByRealEstate(RealEstate realEstate);
        Task Insert(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(Appointment appointment);
    }
}
