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
    public class GetOfficeByIdHandler : IRequestHandler<GetOfficeById, Office>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOfficeByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Office> Handle(GetOfficeById request, CancellationToken cancellationToken)
        {
            var office = await _unitOfWork.OfficeRepository.GetById(request.Id);
            return office;
        }
    }
}
