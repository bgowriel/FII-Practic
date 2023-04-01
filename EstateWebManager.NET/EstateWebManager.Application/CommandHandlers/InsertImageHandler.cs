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
    public class InsertImageHandler : IRequestHandler<InsertImage, Image>
    {
        public readonly IUnitOfWork _unitOfWork;

        public InsertImageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Image> Handle(InsertImage request, CancellationToken cancellationToken)
        {
            var image = new Image
            {
                ImageUri = request.ImageUri,
                RealEstateId = request.RealEstateId
            };

            await _unitOfWork.ImageRepository.Insert(image);
            await _unitOfWork.Save();

            return image;
        }
    }
}
