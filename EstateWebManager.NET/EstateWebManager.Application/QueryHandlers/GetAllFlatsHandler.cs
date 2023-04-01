using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models.AppointmentClasses;
using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Queries
{
    public class GetAllFlatsHandler : IRequestHandler<GetAllFlats, List<Flat>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllFlatsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Flat>> Handle(GetAllFlats request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.FlatRepository.GetAll(request.City);
        }
    }
}
