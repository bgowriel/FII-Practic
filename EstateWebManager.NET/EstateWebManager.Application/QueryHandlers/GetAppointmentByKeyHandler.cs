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
    public class GetAppointmentByKeyHandler : IRequestHandler<GetAppointmentByKey, Appointment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAppointmentByKeyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Appointment> Handle(GetAppointmentByKey request, CancellationToken cancellationToken)
        {
            var appointment = await _unitOfWork.AppointmentRepository
                .GetByKey(request.AgentId, request.ClientId, request.RealEstateId);
            return appointment;
        }
    }
}
