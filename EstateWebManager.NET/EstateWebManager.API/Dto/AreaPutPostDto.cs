using EstateWebManager.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EstateWebManager.API.Dto
{
    public class AreaPutPostDto
    {
        [Required]
        [MaxLength(100)]
        public string? Neighborhood { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(10)]
        public string? ShortName { get; set; }

        [MaxLength(100)]
        public string? County { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(10)]
        public string? PhonePrefix { get; set; }

        [MaxLength(100)]
        public string? Continent { get; set; }

        [MaxLength(100)]
        public string? Pollution { get; set; }

        [MaxLength(100)]
        public string? Traffic { get; set; }

        [MaxLength(100)]
        public string? LivingCost { get; set; }

        [MaxLength(100)]
        public string? Criminality { get; set; }

        [Range(0, 30)]
        public double? AverageTemperature { get; set; }
    }
}
