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
    public class UpdateAppointmentHandler : IRequestHandler<UpdateAppointment, Appointment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAppointmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Appointment> Handle(UpdateAppointment request, CancellationToken cancellationToken)
        {
            var toUpdate = new Appointment
            {
                AgentId = request.AgentId,
                ClientId = request.ClientId,
                RealEstateId = request.RealEstateId,
                Date = request.Date
            };

            _unitOfWork.AppointmentRepository.Update(toUpdate);

            await _unitOfWork.Save();

            return toUpdate;
        }
    }
}
