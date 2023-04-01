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
    public class GetAreasByCountryHandler : IRequestHandler<GetAreasByCountry, List<Area>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAreasByCountryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Area>> Handle(GetAreasByCountry request, CancellationToken cancellationToken)
        {
            var areas = await _unitOfWork.AreaRepository.GetAreasByCountry(request.Country);
            return areas;
        }
    }
}
