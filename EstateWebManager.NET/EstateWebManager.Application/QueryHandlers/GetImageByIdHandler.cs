using EstateWebManager.Application.Abstractions;
using EstateWebManager.Application.Queries;
using EstateWebManager.Domain.Models;
using EstateWebManager.Domain.Models.AppointmentClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.QueryHandlers
{
    public class GetImageByIdHandler : IRequestHandler<GetImageById, Image>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetImageByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Image> Handle(GetImageById request, CancellationToken cancellationToken)
        {
            var image = await _unitOfWork.ImageRepository.GetById(request.Id);
            return image;
        }
    }
}
