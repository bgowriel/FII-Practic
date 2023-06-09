﻿using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Commands
{
    public class DeleteOfficeHandler : IRequestHandler<DeleteOffice, Office>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOfficeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Office> Handle(DeleteOffice request, CancellationToken cancellationToken)
        {
            var office = await _unitOfWork.OfficeRepository.GetById(request.Id);
            if (office == null) return null;

            _unitOfWork.OfficeRepository.Delete(office);
            await _unitOfWork.Save();

            return office;
        }
    }
}
