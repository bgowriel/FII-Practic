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
    public class GetClientByIdHandler : IRequestHandler<GetClientById, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(GetClientById request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientRepository.GetById(request.Id);
            return client;
        }
    }
}
