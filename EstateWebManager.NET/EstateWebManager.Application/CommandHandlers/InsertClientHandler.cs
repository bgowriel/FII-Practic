using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models.AppointmentClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Commands
{
    public class InsertClientHandler : IRequestHandler<InsertClient, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public InsertClientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(InsertClient request, CancellationToken cancellationToken)
        {
            var client = new Client
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber
            };

            await _unitOfWork.ClientRepository.Insert(client);
            await _unitOfWork.Save();

            return client;
        }
    }
}
