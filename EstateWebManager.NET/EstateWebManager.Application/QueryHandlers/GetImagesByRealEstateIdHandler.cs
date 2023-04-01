using EstateWebManager.Application.Abstractions;
using EstateWebManager.Application.Queries;
using EstateWebManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.QueryHandlers
{
    public class GetImagesByRealEstateIdHandler : IRequestHandler<GetImagesByRealEstateId, List<Image>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetImagesByRealEstateIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Image>> Handle(GetImagesByRealEstateId request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ImageRepository.GetByRealEstateId(request.RealEstateId);
        }
    }
}
