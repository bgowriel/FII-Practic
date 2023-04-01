﻿using EstateWebManager.Domain.Enums;
using EstateWebManager.Domain.Models;
using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Commands
{
    public class InsertOffice : IRequest<Office>
    {
        public string UserId { get; set; }
        public EstateTypes Type { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string? ContactMail { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Street { get; set; }
        public string? Number { get; set; }
        public string ZipCode { get; set; }
        public string? Building { get; set; }
        public int? FloorNumber { get; set; }
        public int? DoorNumber { get; set; }
        public int AreaId { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string TransactionType { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }
        public string? PeriodOfTime { get; set; }
        public string Rating { get; set; }
        public int BuiltUpArea { get; set; }
        public string? AC { get; set; } = "yes";
        public string? Internet { get; set; } = "yes";
        public string? ParkingPlace { get; set; } = "yes";
        public DateTime AvailableStarting { get; set; }
    }
}
