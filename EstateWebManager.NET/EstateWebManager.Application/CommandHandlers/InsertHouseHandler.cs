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
    public class InsertHouseHandler : IRequestHandler<InsertHouse, House>
    {
        private readonly IUnitOfWork _unitOfWork;

        public InsertHouseHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<House> Handle(InsertHouse request, CancellationToken cancellationToken)
        {
            var house = new House
            {
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
                YearBuilt = request.YearBuilt,
                BuiltUpArea = request.BuiltUpArea,
                LandArea = request.LandArea,
                Floors = request.Floors,
                Bedrooms = request.Bedrooms,
                Bathrooms = request.Bathrooms,
                Heating = request.Heating,
                AC = request.AC,
                Internet = request.Internet,
                Garage = request.Garage,
                SwimmingPool = request.SwimmingPool,
                AvailableStarting = request.AvailableStarting
            };

            await _unitOfWork.HouseRepository.Insert(house);
            await _unitOfWork.Save();

            return house;
        }
    }
}
