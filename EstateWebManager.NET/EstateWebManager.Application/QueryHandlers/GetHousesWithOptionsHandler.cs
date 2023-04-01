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
    public class GetHousesWithOptionsHandler : IRequestHandler<GetHousesWithOptions, List<House>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHousesWithOptionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<House>> Handle(GetHousesWithOptions request, CancellationToken cancellationToken)
        {
            var houses = await _unitOfWork.HouseRepository.GetWithOptions(request.City,
                                                                          request.TransactionType,
                                                                          request.MinYearBuilt,
                                                                          request.MinBuiltUpArea,
                                                                          request.MinLandArea,
                                                                          request.Bedrooms,
                                                                          request.Bathrooms,
                                                                          request.AC,
                                                                          request.Internet,
                                                                          request.Garage,
                                                                          request.SwimmingPool);
            return houses;
        }
    }
}
