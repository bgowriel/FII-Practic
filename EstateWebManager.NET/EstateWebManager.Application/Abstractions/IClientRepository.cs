using EstateWebManager.Domain.Models.AppointmentClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Abstractions
{
    public interface IClientRepository
    {
        Task<Client?> GetById(int clientId);
        Task<Client?> GetByName(string name);
        Task<List<Client>?> GetAll();
        Task Insert(Client client);
        void Update(Client client);
        void Delete(Client client);
    }
}
