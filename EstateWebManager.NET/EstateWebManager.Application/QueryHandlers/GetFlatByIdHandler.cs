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
    public class GetFlatByIdHandler : IRequestHandler<GetFlatById, Flat>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFlatByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Flat> Handle(GetFlatById request, CancellationToken cancellationToken)
        {
            var flat = await _unitOfWork.FlatRepository.GetById(request.Id);
            return flat;
        }
    }
}
