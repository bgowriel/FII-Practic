using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EstateWebManager.Application.Queries
{
    public class GetOfficesByPriceRange : IRequest<List<Office>>
    {
        public string City { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public string Currency { get; set; }
    }
}
