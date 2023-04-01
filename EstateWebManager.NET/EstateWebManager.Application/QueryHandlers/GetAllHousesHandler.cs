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
    public class GetAllHousesHandler : IRequestHandler<GetAllHouses, List<House>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllHousesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<House>> Handle(GetAllHouses request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.HouseRepository.GetAll(request.City);
        }
    }
}
