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
    public class DeleteFlatHandler : IRequestHandler<DeleteFlat, Flat>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFlatHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Flat> Handle(DeleteFlat request, CancellationToken cancellationToken)
        {
            var flat = await _unitOfWork.FlatRepository.GetById(request.Id);
            if (flat == null) return null;

            _unitOfWork.FlatRepository.Delete(flat);
            await _unitOfWork.Save();

            return flat;
        }
    }
}
