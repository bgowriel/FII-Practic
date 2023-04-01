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
    public class GetAppointmentsByAgentNameHandler : IRequestHandler<GetAppointmentsByAgentName, List<Appointment>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAppointmentsByAgentNameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Appointment>> Handle(GetAppointmentsByAgentName request, CancellationToken cancellationToken)
        {
            var appointments = await _unitOfWork.AppointmentRepository
                .GetByAgentName(request.AgentName);
            return appointments;
        }
    }
}
