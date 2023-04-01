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
    public class UpdateAgentHandler : IRequestHandler<UpdateAgent, EstateAgent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAgentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EstateAgent> Handle(UpdateAgent request, CancellationToken cancellationToken)
        {
            var toUpdate = new EstateAgent
            {
                Id = request.Id,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber
            };

            _unitOfWork.AgentRepository.Update(toUpdate);

            await _unitOfWork.Save();

            return toUpdate;
        }
    }
}
