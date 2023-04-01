using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models;
using EstateWebManager.Domain.Models.AppointmentClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Queries
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClients, List<Client>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllClientsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Client>> Handle(GetAllClients request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ClientRepository.GetAll();
        }
    }
}
