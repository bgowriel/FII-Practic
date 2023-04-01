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
    public class UpdateClientHandler : IRequestHandler<UpdateClient, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(UpdateClient request, CancellationToken cancellationToken)
        {
            var toUpdate = new Client
            {
                Id = request.Id,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber
            };

            _unitOfWork.ClientRepository.Update(toUpdate);

            await _unitOfWork.Save();

            return toUpdate;
        }
    }
}
