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
    public class GetLandsByLandAreaHandler : IRequestHandler<GetLandsByLandArea, List<Land>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLandsByLandAreaHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Land>> Handle(GetLandsByLandArea request, CancellationToken cancellationToken)
        {
            var lands = await _unitOfWork.LandRepository.GetByLandArea(request.City,
                                                                       request.MinLandArea,
                                                                       request.MaxLandArea);
            return lands;
        }
    }
}
