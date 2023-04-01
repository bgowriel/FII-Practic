using EstateWebManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Queries
{
    public class GetImagesByRealEstateId : IRequest<List<Image>>
    {
        public int RealEstateId { get; set; }
    }
}
