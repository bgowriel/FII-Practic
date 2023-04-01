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
    public class GetOfficesByRatingHandler : IRequestHandler<GetOfficesByRating, List<Office>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOfficesByRatingHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Office>> Handle(GetOfficesByRating request, CancellationToken cancellationToken)
        {
            var offices = await _unitOfWork.OfficeRepository.GetByRating(request.City,
                                                                         request.Rating);
            return offices;
        }
    }
}
