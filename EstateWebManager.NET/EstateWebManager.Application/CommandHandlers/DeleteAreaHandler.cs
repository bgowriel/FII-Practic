using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Commands
{
    public class DeleteAreaHandler : IRequestHandler<DeleteArea, Area>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAreaHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Area> Handle(DeleteArea request, CancellationToken cancellationToken)
        {
            var area = await _unitOfWork.AreaRepository.GetById(request.Id);
            if (area == null) return null;
            //FA VERIFICARE FK CONSTRAINT; RETURN ENTITYNOTFOUNDEXCEPTION()
            _unitOfWork.AreaRepository.Delete(area);
            await _unitOfWork.Save();

            return area;
        }
    }
}
