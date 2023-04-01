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
    public class GetLandsByPriceRangeHandler : IRequestHandler<GetLandsByPriceRange, List<Land>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLandsByPriceRangeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Land>> Handle(GetLandsByPriceRange request, CancellationToken cancellationToken)
        {
            var lands = await _unitOfWork.LandRepository.GetByPriceRange(request.City,
                                                                         request.Min,
                                                                         request.Max,
                                                                         request.Currency);
            return lands;
        }
    }
}
