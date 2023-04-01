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
    public class GetFlatsByPriceRangeHandler : IRequestHandler<GetFlatsByPriceRange, List<Flat>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFlatsByPriceRangeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Flat>> Handle(GetFlatsByPriceRange request, CancellationToken cancellationToken)
        {
            var flats = await _unitOfWork.FlatRepository.GetByPriceRange(request.City,
                                                                         request.Min,
                                                                         request.Max,
                                                                         request.Currency);
            return flats;
        }
    }
}
