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
    public class GetLandByIdHandler : IRequestHandler<GetLandById, Land>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLandByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Land> Handle(GetLandById request, CancellationToken cancellationToken)
        {
            var land = await _unitOfWork.LandRepository.GetById(request.Id);
            return land;
        }
    }
}
