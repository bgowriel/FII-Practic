using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Queries
{
    public class GetHousesWithOptions : IRequest<List<House>>
    {
        public string City { get; set; }
        public string TransactionType { get; set; }
        public int MinYearBuilt { get; set; }
        public int MinBuiltUpArea { get; set; }
        public int MinLandArea { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public bool AC { get; set; }
        public bool Internet { get; set; }
        public bool Garage { get; set; }
        public bool SwimmingPool { get; set; }
    }
}
