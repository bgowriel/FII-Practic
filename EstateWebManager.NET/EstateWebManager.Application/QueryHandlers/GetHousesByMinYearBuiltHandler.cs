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
    public class GetHousesByMinYearBuiltHandler : IRequestHandler<GetHousesByMinYearBuilt, List<House>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHousesByMinYearBuiltHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<House>> Handle(GetHousesByMinYearBuilt request, CancellationToken cancellationToken)
        {
            var houses = await _unitOfWork.HouseRepository.GetByMinYearBuilt(request.City, request.MinYearBuilt);
            return houses;
        }
    }
}
