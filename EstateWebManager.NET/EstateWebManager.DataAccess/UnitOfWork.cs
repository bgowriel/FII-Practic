using EstateWebManager.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;

        public IAreaRepository AreaRepository { get; private set; }
        public IFlatRepository FlatRepository { get; private set; }
        public IOfficeRepository OfficeRepository { get; private set; }
        public IHouseRepository HouseRepository { get; private set; }
        public ILandRepository LandRepository { get; private set; }
        public IAgentRepository AgentRepository { get; private set; }
        public IClientRepository ClientRepository { get; private set; }
        public IAppointmentRepository AppointmentRepository { get; private set; }
        public IImageRepository ImageRepository { get; private set; }

        public UnitOfWork(DatabaseContext dataContext, 
            IAreaRepository areaRepository,
            IFlatRepository flatRepository,
            IOfficeRepository officeRepository,
            IHouseRepository houseRepository,
            ILandRepository landRepository,
            IAgentRepository agentRepository,
            IClientRepository clientRepository,
            IAppointmentRepository appointmentRepository,
            IImageRepository imageRepository)
        {
            _databaseContext = dataContext;
            AreaRepository = areaRepository;
            FlatRepository = flatRepository;
            OfficeRepository = officeRepository;
            HouseRepository = houseRepository;
            LandRepository = landRepository;
            AgentRepository = agentRepository;
            ClientRepository = clientRepository;
            AppointmentRepository = appointmentRepository;
            ImageRepository = imageRepository;
        }

        public async Task Save()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _databaseContext.Dispose();
        }
    }
}
