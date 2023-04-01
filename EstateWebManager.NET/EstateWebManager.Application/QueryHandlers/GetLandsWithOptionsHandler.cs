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
    public class GetLandsWithOptionsHandler : IRequestHandler<GetLandsWithOptions, List<Land>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLandsWithOptionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Land>> Handle(GetLandsWithOptions request, CancellationToken cancellationToken)
        {
            var lands = await _unitOfWork.LandRepository.GetWithOptions(request.City,
                                                                        request.MinLandArea,
                                                                        request.MaxLandArea,
                                                                        request.Electricity,
                                                                        request.Water,
                                                                        request.Sewerage,
                                                                        request.Heating);
            return lands;
        }
    }
}
