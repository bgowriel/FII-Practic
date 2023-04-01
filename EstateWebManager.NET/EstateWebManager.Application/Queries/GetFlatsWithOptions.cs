using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Queries
{
    public class GetFlatsWithOptions : IRequest<List<Flat>>
    {
        public string City { get; set; }
        public string TransactionType { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public bool AC { get; set; }
        public bool Internet { get; set; }
        public bool ParkingPlace { get; set; }
    }
}
