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
    public class GetOfficesWithOptionsHandler : IRequestHandler<GetOfficesWithOptions, List<Office>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOfficesWithOptionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Office>> Handle(GetOfficesWithOptions request, CancellationToken cancellationToken)
        {
            var offices = await _unitOfWork.OfficeRepository.GetWithOptions(request.City,
                                                                            request.Rating,
                                                                            request.MinBuiltUpArea,
                                                                            request.AC,
                                                                            request.Internet,
                                                                            request.ParkingPlace);
            return offices;
        }
    }
}
