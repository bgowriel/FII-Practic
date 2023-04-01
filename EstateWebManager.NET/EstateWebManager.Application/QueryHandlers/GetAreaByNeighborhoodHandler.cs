using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Queries
{
    public class GetAreaByNeighborhoodHandler : IRequestHandler<GetAreaByNeighborhood, Area>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAreaByNeighborhoodHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Area> Handle(GetAreaByNeighborhood request, CancellationToken cancellationToken)
        {
            var area = await _unitOfWork.AreaRepository.GetByNeighborhood(request.City,
                                                                          request.Neighborhood);
            return area;
        }
    }
}
