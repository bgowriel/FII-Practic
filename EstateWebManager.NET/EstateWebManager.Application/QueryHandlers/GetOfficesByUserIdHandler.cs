using EstateWebManager.Application.Abstractions;
using EstateWebManager.Application.Queries;
using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.QueryHandlers
{
    public class GetOfficesByUserIdHandler : IRequestHandler<GetOfficesByUserId, List<Office>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOfficesByUserIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Office>> Handle(GetOfficesByUserId request, CancellationToken cancellationToken)
        {
            var offices = await _unitOfWork.OfficeRepository.GetByUserId(request.UserId);
            return offices;
        }
    }
}
