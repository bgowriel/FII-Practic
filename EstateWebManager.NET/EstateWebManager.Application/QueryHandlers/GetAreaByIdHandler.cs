using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Queries
{
    public class GetAreaByIdHandler : IRequestHandler<GetAreaById, Area>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAreaByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Area> Handle(GetAreaById request, CancellationToken cancellationToken)
        {
            var area = await _unitOfWork.AreaRepository.GetById(request.Id);
            return area;
        }
    }
}
