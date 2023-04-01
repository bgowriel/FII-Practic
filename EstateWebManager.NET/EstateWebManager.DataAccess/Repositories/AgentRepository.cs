using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models.AppointmentClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.DataAccess.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly DatabaseContext _databaseContext;

        public AgentRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<EstateAgent?> GetById(int agentId)
        {
            var agent = await _databaseContext.EstateAgents
                .Include(agent => agent.Appointments)
                .SingleOrDefaultAsync(agent => agent.Id == agentId);
            return agent;
        }

        public async Task<EstateAgent?> GetByName(string name)
        {
            var agent = await _databaseContext.EstateAgents
                .Include(agent => agent.Appointments)
                .SingleOrDefaultAsync(agent => agent.Name == name);
            return agent;
        }

        public async Task<List<EstateAgent>?> GetAll()
        {
            var agents = await _databaseContext.EstateAgents
                .Include(agent => agent.Appointments)
                .Take(100)
                .ToListAsync();
            return agents;
        }

        public async Task Insert(EstateAgent agent)
        {
            await _databaseContext.EstateAgents.AddAsync(agent);
        }

        public void Update(EstateAgent agent)
        {
            _databaseContext.EstateAgents.Update(agent);
        }
        public void Delete(EstateAgent agent)
        {
            _databaseContext.EstateAgents.Remove(agent);
        }
    }
}
