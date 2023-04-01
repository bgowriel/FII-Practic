using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Queries
{
    public class GetOfficesWithOptions : IRequest<List<Office>>
    {
        public string City { get; set; }
        public string Rating { get; set; }
        public int MinBuiltUpArea { get; set; }
        public bool AC { get; set; }
        public bool Internet { get; set; }
        public bool ParkingPlace { get; set; }
    }
}
