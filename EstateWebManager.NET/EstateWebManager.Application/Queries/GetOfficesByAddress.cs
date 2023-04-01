using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Queries
{
    public class GetOfficesByAddress : IRequest<List<Office>>
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string Country { get; set; }
    }
}
