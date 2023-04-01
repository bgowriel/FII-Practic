using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EstateWebManager.Application.Queries
{
    public class GetHousesByMinAreas : IRequest<List<House>>
    {
        public string City { get; set; }
        public int MinBuiltUpArea { get; set; }
        public int MinLandArea { get; set; }
    }
}
