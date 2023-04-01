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
    public class DeleteAppointmentHandler : IRequestHandler<DeleteAppointment, Appointment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAppointmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Appointment> Handle(DeleteAppointment request, CancellationToken cancellationToken)
        {
            var appointment = await _unitOfWork.AppointmentRepository
                .GetByKey(request.AgentId, request.ClientId, request.RealEstateId);
            if (appointment == null) return null;

            _unitOfWork.AppointmentRepository.Delete(appointment);
            await _unitOfWork.Save();

            return appointment;
        }
    }
}
