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
    public class GetAppointmentsByClientIdHandler : IRequestHandler<GetAppointmentsByClientId, List<Appointment>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAppointmentsByClientIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Appointment>> Handle(GetAppointmentsByClientId request, CancellationToken cancellationToken)
        {
            var appointments = await _unitOfWork.AppointmentRepository
                .GetByClientId(request.ClientId);
            return appointments;
        }
    }
}
