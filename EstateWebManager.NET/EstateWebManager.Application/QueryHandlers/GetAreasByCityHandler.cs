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
    public class GetAreasByCityHandler : IRequestHandler<GetAreasByCity, List<Area>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAreasByCityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Area>> Handle(GetAreasByCity request, CancellationToken cancellationToken)
        {
            var areas = await _unitOfWork.AreaRepository.GetAreasByCity(request.City);
            return areas;
        }
    }
}
