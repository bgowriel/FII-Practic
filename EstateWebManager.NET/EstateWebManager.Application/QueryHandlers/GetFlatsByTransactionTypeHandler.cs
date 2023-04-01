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
    public class GetFlatsByTransactionTypeHandler : IRequestHandler<GetFlatsByTransactionType, List<Flat>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFlatsByTransactionTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Flat>> Handle(GetFlatsByTransactionType request, CancellationToken cancellationToken)
        {
            var flats = await _unitOfWork.FlatRepository.GetByTransactionType(request.City, request.TransactionType);
            return flats;
        }
    }
}
