using EstateWebManager.Application.Abstractions;
using EstateWebManager.Application.Commands;
using EstateWebManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.CommandHandlers
{
    public class DeleteImageHandler : IRequestHandler<DeleteImage, Image>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteImageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Image> Handle(DeleteImage request, CancellationToken cancellationToken)
        {
            var image = await _unitOfWork.ImageRepository.GetById(request.Id);
            if (image == null) return null;

            _unitOfWork.ImageRepository.Delete(image);
            await _unitOfWork.Save();

            return image;
        }
    }
}
