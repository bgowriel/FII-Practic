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
    public class DeleteAgentHandler : IRequestHandler<DeleteAgent, EstateAgent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAgentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EstateAgent> Handle(DeleteAgent request, CancellationToken cancellationToken)
        {
            var agent = await _unitOfWork.AgentRepository.GetById(request.Id);
            if (agent == null) return null;

            _unitOfWork.AgentRepository.Delete(agent);
            await _unitOfWork.Save();

            return agent;
        }
    }
}
