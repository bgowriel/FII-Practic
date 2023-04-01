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
    public class GetAllAgentsHandler : IRequestHandler<GetAllAgents, List<EstateAgent>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAgentsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<EstateAgent>> Handle(GetAllAgents request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.AgentRepository.GetAll();
        }
    }
}
