using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Commands
{
    public class DeleteHouseHandler : IRequestHandler<DeleteHouse, House>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteHouseHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<House> Handle(DeleteHouse request, CancellationToken cancellationToken)
        {
            var house = await _unitOfWork.HouseRepository.GetById(request.Id);
            if (house == null) return null;

            _unitOfWork.HouseRepository.Delete(house);
            await _unitOfWork.Save();

            return house;
        }
    }
}
