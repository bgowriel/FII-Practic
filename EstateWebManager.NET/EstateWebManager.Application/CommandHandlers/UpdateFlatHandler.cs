﻿using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Enums;
using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Commands
{
    public class UpdateFlatHandler : IRequestHandler<UpdateFlat, Flat>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFlatHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Flat> Handle(UpdateFlat request, CancellationToken cancellationToken)
        {
            var toUpdate = new Flat
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
                BuiltUpArea = request.BuiltUpArea,
                Bedrooms = request.Bedrooms,
                Bathrooms = request.Bathrooms,
                Heating = request.Heating,
                AC = request.AC,
                Internet = request.Internet,
                ParkingPlace = request.ParkingPlace,
                AvailableStarting = request.AvailableStarting
            };

            _unitOfWork.FlatRepository.Update(toUpdate);

            await _unitOfWork.Save();

            return toUpdate;
        }
    }
}
