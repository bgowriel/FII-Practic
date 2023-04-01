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
    public class GetAllLandsHandler : IRequestHandler<GetAllLands, List<Land>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllLandsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Land>> Handle(GetAllLands request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.LandRepository.GetAll(request.City);
        }
    }
}
