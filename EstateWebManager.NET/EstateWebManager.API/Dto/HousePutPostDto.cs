using EstateWebManager.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EstateWebManager.API.Dto
{
    public class HousePutPostDto
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

        [Range(1960, 2023)]
        public int YearBuilt { get; set; }

        [Range(0, 500)]
        public int BuiltUpArea { get; set; }

        [Range(0, 10_000)]
        public int LandArea { get; set; }

        [Range(0, 5)]
        public int Floors { get; set; }

        [Range(1, 10)]
        public int Bedrooms { get; set; }

        [Range(1, 5)]
        public int Bathrooms { get; set; }

        [MaxLength(50)]
        public string? Heating { get; set; } = "individual gas heating station";

        [MaxLength(50)]
        public string? AC { get; set; } = "no";

        [MaxLength(50)]
        public string? Internet { get; set; } = "yes";

        [MaxLength(50)]
        public string? Garage { get; set; } = "yes";

        [MaxLength(50)]
        public string? SwimmingPool { get; set; } = "no";

        [Required]
        public DateTime AvailableStarting { get; set; }
    }
}
