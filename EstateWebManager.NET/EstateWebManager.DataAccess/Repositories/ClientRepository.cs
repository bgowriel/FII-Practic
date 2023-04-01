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
    public class ClientRepository : IClientRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ClientRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Client?> GetById(int clientId)
        {
            var client = await _databaseContext.Clients
                .Include(client => client.Appointments)
                .SingleOrDefaultAsync(client => client.Id == clientId);
            return client;
        }

        public async Task<Client?> GetByName(string name)
        {
            var client = await _databaseContext.Clients
                .Include(client => client.Appointments)
                .SingleOrDefaultAsync(client => client.Name == name);
            return client;
        }
        public async Task<List<Client>?> GetAll()
        {
            var clients = await _databaseContext.Clients
                .Include(client => client.Appointments)
                .Take(500)
                .ToListAsync();
            return clients;
        }
        public async Task Insert(Client client)
        {
            await _databaseContext.Clients.AddAsync(client);
        }

        public void Update(Client client)
        {
            _databaseContext.Clients.Update(client);
        }
        public void Delete(Client client)
        {
            _databaseContext.Clients.Remove(client);
        }
    }
}
