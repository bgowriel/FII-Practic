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
    public class UpdateAppointment : IRequest<Appointment>
    {
        public int AgentId { get; set; }
        public int ClientId { get; set; }
        public int RealEstateId { get; set; }
        public DateTime Date { get; set; }
    }
}
