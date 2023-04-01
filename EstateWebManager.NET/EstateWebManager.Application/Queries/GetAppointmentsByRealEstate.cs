using EstateWebManager.Domain.Models;
using EstateWebManager.Domain.Models.AppointmentClasses;
using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Queries
{
    public class GetAppointmentsByRealEstate : IRequest<List<Appointment>>
    {
        public RealEstate RealEstate { get; set; }
    }
}
