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
    public class GetHousesByPriceRangeHandler : IRequestHandler<GetHousesByPriceRange, List<House>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHousesByPriceRangeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<House>> Handle(GetHousesByPriceRange request, CancellationToken cancellationToken)
        {
            var houses = await _unitOfWork.HouseRepository.GetByPriceRange(request.City,
                                                                           request.Min,
                                                                           request.Max,
                                                                           request.Currency);
            return houses;
        }
    }
}
