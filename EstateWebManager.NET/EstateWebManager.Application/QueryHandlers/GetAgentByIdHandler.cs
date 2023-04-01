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
    public class GetAgentByIdHandler : IRequestHandler<GetAgentById, EstateAgent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAgentByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EstateAgent> Handle(GetAgentById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.AgentRepository.GetById(request.Id);
        }
    }
}
