using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Enums;
using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Commands
{
    public class UpdateOfficeHandler : IRequestHandler<UpdateOffice, Office>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOfficeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Office> Handle(UpdateOffice request, CancellationToken cancellationToken)
        {
            var toUpdate = new Office
            {
                Id = request.Id,
                Type = request.Type,
                Title = request.Title,
                Description = request.Description,
                ContactName = request.ContactName,
                ContactPhone = request.ContactPhone,
                ContactMail = request.ContactMail,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Street = request.Street,
                Number = request.Number,
                ZipCode = request.ZipCode,
                Building = request.Building,
                FloorNumber = request.FloorNumber,
                DoorNumber = request.DoorNumber,
                AreaId = request.AreaId,
                LastUpdate = request.LastUpdate,
                TransactionType = request.TransactionType,
                Price = request.Price,
                Currency = request.Currency,
                PeriodOfTime = request.PeriodOfTime,
                Rating = request.Rating,
                BuiltUpArea = request.BuiltUpArea,
                AC = request.AC,
                Internet = request.Internet,
                ParkingPlace = request.ParkingPlace,
                AvailableStarting = request.AvailableStarting
            };

            _unitOfWork.OfficeRepository.Update(toUpdate);

            await _unitOfWork.Save();

            return toUpdate;
        }
    }
}
