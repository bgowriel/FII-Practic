using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        public IAreaRepository AreaRepository { get; }
        public IFlatRepository FlatRepository { get; }
        public IOfficeRepository OfficeRepository { get; }
        public IHouseRepository HouseRepository { get; }
        public ILandRepository LandRepository { get; }
        public IAgentRepository AgentRepository { get; }
        public IClientRepository ClientRepository { get; }
        public IAppointmentRepository AppointmentRepository { get; }
        public IImageRepository ImageRepository { get; }
        Task Save();
    }
}
