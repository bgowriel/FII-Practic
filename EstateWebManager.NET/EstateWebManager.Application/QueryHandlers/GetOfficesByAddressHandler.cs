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
    public class GetOfficesByAddressHandler : IRequestHandler<GetOfficesByAddress, List<Office>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOfficesByAddressHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Office>> Handle(GetOfficesByAddress request, CancellationToken cancellationToken)
        {
            var offices = await _unitOfWork.OfficeRepository.GetByAddress(request.Street,
                                                                       request.City,
                                                                       request.Country);
            return offices;
        }
    }
}
