using EstateWebManager.Domain.Models.AppointmentClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Abstractions
{
    public interface IAgentRepository
    {
        Task<EstateAgent?> GetById(int agentId);
        Task<EstateAgent?> GetByName(string name);
        Task<List<EstateAgent>?> GetAll();
        Task Insert(EstateAgent agent);
        void Update(EstateAgent agent);
        void Delete(EstateAgent agent);
    }
}
