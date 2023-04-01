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
    public class InsertAgentHandler : IRequestHandler<InsertAgent, EstateAgent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public InsertAgentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EstateAgent> Handle(InsertAgent request, CancellationToken cancellationToken)
        {
            var agent = new EstateAgent
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber
            };

            await _unitOfWork.AgentRepository.Insert(agent);
            await _unitOfWork.Save();

            return agent;
        }
    }
}
