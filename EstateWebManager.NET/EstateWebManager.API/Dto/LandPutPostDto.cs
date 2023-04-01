using EstateWebManager.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EstateWebManager.API.Dto
{
    public class LandPutPostDto
    {
        public EstateTypes Type { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContactName { get; set; }

        [Required]
        [Phone]
        public string ContactPhone { get; set; }

        [EmailAddress]
        public string? ContactMail { get; set; }

        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Range(-180, 180)]
        public double Longitude { get; set; }

        [Required]
        [MaxLength(50)]
        public string Street { get; set; }

        public string? Number { get; set; }

        [Required]
        [MaxLength(50)]
        public string ZipCode { get; set; }

        public string? Building { get; set; }

        [Range(0, 100)]
        public int? FloorNumber { get; set; }

        [Range(0, 1_000)]
        public int? DoorNumber { get; set; }

        [Required]
        public int AreaId { get; set; }

        public DateTime? LastUpdate { get; set; }

        [Required]
        [MaxLength(5)]
        public string TransactionType { get; set; }

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [Required]
        [MaxLength(15)]
        public string Currency { get; set; }

        public string? PeriodOfTime { get; set; }

        [Range(300, 50_000)]
        public int LandArea { get; set; }

        [MaxLength(50)]
        public string? Topography { get; set; } = "plain";

        [MaxLength(50)]
        public string? Fence { get; set; } = "wired";

        [MaxLength(50)]
        public string? CurrentStatus { get; set; } = "meadow";

        [MaxLength(50)]
        public string? Electricity { get; set; } = "no";

        [MaxLength(50)]
        public string? Water { get; set; } = "no";

        [MaxLength(50)]
        public string? Sewerage { get; set; } = "no";

        [MaxLength(50)]
        public string? Heating { get; set; } = "no";

        [Required]
        public DateTime AvailableStarting { get; set; }
    }
}
