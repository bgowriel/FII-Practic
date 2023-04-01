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
    public class DeleteLandHandler : IRequestHandler<DeleteLand, Land>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Land> Handle(DeleteLand request, CancellationToken cancellationToken)
        {
            var land = await _unitOfWork.LandRepository.GetById(request.Id);
            if (land == null) return null;

            _unitOfWork.LandRepository.Delete(land);
            await _unitOfWork.Save();

            return land;
        }
    }
}
