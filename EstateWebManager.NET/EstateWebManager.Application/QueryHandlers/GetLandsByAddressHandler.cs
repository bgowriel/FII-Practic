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
    public class GetLandsByAddressHandler : IRequestHandler<GetLandsByAddress, List<Land>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLandsByAddressHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Land>> Handle(GetLandsByAddress request, CancellationToken cancellationToken)
        {
            var lands = await _unitOfWork.LandRepository.GetByAddress(request.Street,
                                                                      request.City,
                                                                      request.Country);
            return lands;
        }
    }
}
