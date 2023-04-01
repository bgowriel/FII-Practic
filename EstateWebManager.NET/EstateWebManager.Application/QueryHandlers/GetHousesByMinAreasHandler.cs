using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EstateWebManager.Application.Queries
{
    public class GetHousesByMinAreasHandler : IRequestHandler<GetHousesByMinAreas, List<House>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHousesByMinAreasHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<House>> Handle(GetHousesByMinAreas request, CancellationToken cancellationToken)
        {
            var houses = await _unitOfWork.HouseRepository.GetByMinAreas(request.City,
                                                                         request.MinBuiltUpArea,
                                                                         request.MinLandArea);
            return houses;
        }
    }
}
