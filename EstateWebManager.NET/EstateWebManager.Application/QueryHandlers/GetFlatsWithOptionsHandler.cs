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
    public class GetFlatsWithOptionsHandler : IRequestHandler<GetFlatsWithOptions, List<Flat>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFlatsWithOptionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Flat>> Handle(GetFlatsWithOptions request, CancellationToken cancellationToken)
        {
            var flats = await _unitOfWork.FlatRepository.GetWithOptions(request.City,
                                                                        request.TransactionType,
                                                                        request.Bedrooms,
                                                                        request.Bathrooms,
                                                                        request.AC,
                                                                        request.Internet,
                                                                        request.ParkingPlace);
            return flats;
        }
    }
}
