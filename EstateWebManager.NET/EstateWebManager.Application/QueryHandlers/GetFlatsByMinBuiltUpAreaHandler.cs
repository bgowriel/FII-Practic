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
    public class GetFlatsByMinBuiltUpAreaHandler : IRequestHandler<GetFlatsByMinBuiltUpArea, List<Flat>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFlatsByMinBuiltUpAreaHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Flat>> Handle(GetFlatsByMinBuiltUpArea request, CancellationToken cancellationToken)
        {
            var flats = await _unitOfWork.FlatRepository.GetByMinBuiltUpArea(request.City, request.MinBuiltUpArea);
            return flats;
        }
    }
}
