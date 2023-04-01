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
    public class GetHousesByAddressHandler : IRequestHandler<GetHousesByAddress, List<House>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHousesByAddressHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<House>> Handle(GetHousesByAddress request, CancellationToken cancellationToken)
        {
            var houses = await _unitOfWork.HouseRepository.GetByAddress(request.Street,
                                                                        request.City,
                                                                        request.Country);
            return houses;
        }
    }
}
