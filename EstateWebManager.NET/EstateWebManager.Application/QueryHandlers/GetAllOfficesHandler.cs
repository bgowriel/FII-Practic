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
    public class GetAllOfficesHandler : IRequestHandler<GetAllOffices, List<Office>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllOfficesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Office>> Handle(GetAllOffices request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.OfficeRepository.GetAll(request.City);
        }
    }
}
