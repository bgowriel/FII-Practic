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
    public class UpdateLandHandler : IRequestHandler<UpdateLand, Land>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Land> Handle(UpdateLand request, CancellationToken cancellationToken)
        {
            var toUpdate = new Land
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
                LandArea = request.LandArea,
                Topography = request.Topography,
                Fence = request.Fence,
                CurrentStatus = request.CurrentStatus,
                Electricity = request.Electricity,
                Water = request.Water,
                Sewerage = request.Sewerage,
                Heating = request.Heating,
                AvailableStarting = request.AvailableStarting
            };

            _unitOfWork.LandRepository.Update(toUpdate);

            await _unitOfWork.Save();

            return toUpdate;
        }
    }
}
