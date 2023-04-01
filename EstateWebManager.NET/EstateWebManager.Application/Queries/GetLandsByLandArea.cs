using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EstateWebManager.Application.Queries
{
    public class GetLandsByLandArea : IRequest<List<Land>>
    {
        public string City { get; set; }
        public int MinLandArea { get; set; }
        public int MaxLandArea { get; set; }
    }
}
