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
    public class GetHouseByIdHandler : IRequestHandler<GetHouseById, House>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHouseByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<House> Handle(GetHouseById request, CancellationToken cancellationToken)
        {
            var house = await _unitOfWork.HouseRepository.GetById(request.Id);
            return house;
        }
    }
}
