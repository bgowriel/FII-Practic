using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models;
using EstateWebManager.Domain.Models.AppointmentClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Queries
{
    public class GetAllAreasHandler : IRequestHandler<GetAllAreas, List<Area>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAreasHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Area>> Handle(GetAllAreas request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.AreaRepository.GetAll();
        }
    }
}
