using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models.AppointmentClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Commands
{
    public class DeleteClientHandler : IRequestHandler<DeleteClient, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(DeleteClient request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientRepository.GetById(request.Id);
            if (client == null) return null;

            _unitOfWork.ClientRepository.Delete(client);
            await _unitOfWork.Save();

            return client;
        }
    }
}
