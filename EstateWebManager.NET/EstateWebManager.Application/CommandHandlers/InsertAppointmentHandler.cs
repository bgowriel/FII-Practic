using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models.AppointmentClasses;
using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Commands
{
    public class InsertAppointmentHandler : IRequestHandler<InsertAppointment, Appointment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public InsertAppointmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Appointment> Handle(InsertAppointment request, CancellationToken cancellationToken)
        {
            var appointment = new Appointment
            {
                AgentId = request.AgentId,
                ClientId = request.ClientId,
                RealEstateId = request.RealEstateId,
                Date = request.Date
            };

            await _unitOfWork.AppointmentRepository.Insert(appointment);
            await _unitOfWork.Save();

            return appointment;
        }
    }
}
