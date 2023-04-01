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
    public class InsertLand : IRequest<Land>
    {
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
        public int LandArea { get; set; }
        public string? Topography { get; set; } = "plain";
        public string? Fence { get; set; } = "wired";
        public string? CurrentStatus { get; set; } = "meadow";
        public string? Electricity { get; set; } = "no";
        public string? Water { get; set; } = "no";
        public string? Sewerage { get; set; } = "no";
        public string? Heating { get; set; } = "no";
        public DateTime AvailableStarting { get; set; }
    }
}
