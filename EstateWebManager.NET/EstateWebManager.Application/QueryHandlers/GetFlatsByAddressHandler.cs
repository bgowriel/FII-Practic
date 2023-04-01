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
    public class GetFlatsByAddressHandler : IRequestHandler<GetFlatsByAddress, List<Flat>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFlatsByAddressHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Flat>> Handle(GetFlatsByAddress request, CancellationToken cancellationToken)
        {
            var flats = await _unitOfWork.FlatRepository.GetByAddress(request.Street, request.City, request.Country);
            return flats;
        }
    }
}
