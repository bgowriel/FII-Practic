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
    public class GetOfficesByPriceRangeHandler : IRequestHandler<GetOfficesByPriceRange, List<Office>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOfficesByPriceRangeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Office>> Handle(GetOfficesByPriceRange request, CancellationToken cancellationToken)
        {
            var offices = await _unitOfWork.OfficeRepository.GetByPriceRange(request.City,
                                                                             request.Min,
                                                                             request.Max,
                                                                             request.Currency);
            return offices;
        }
    }
}
