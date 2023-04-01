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
    public class GetAppointmentByKey : IRequest<Appointment>
    {
        public int AgentId { get; set; }
        public int ClientId { get; set; }
        public int RealEstateId { get; set; }
    }
}
