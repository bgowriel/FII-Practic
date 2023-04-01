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
    public class GetHousesByTransactionTypeHandler : IRequestHandler<GetHousesByTransactionType, List<House>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHousesByTransactionTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<House>> Handle(GetHousesByTransactionType request, CancellationToken cancellationToken)
        {
            var houses = await _unitOfWork.HouseRepository.GetByTransactionType(request.City,
                                                                                request.TransactionType);
            return houses;
        }
    }
}
