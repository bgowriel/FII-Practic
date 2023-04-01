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
    public class GetClientByNameHandler : IRequestHandler<GetClientByName, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientByNameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(GetClientByName request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientRepository.GetByName(request.Name);
            return client;
        }
    }
}
