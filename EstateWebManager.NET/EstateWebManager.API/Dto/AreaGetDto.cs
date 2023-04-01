using EstateWebManager.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EstateWebManager.API.Dto
{
    public class AreaGetDto
    {
        public int Id { get; set; }

        public string? Neighborhood { get; set; }

        public string City { get; set; }

        public string? ShortName { get; set; }

        public string? County { get; set; }

        public string Country { get; set; }

        public string? PhonePrefix { get; set; }

        public string? Continent { get; set; }

        public string? Pollution { get; set; }

        public string? Traffic { get; set; }

        public string? LivingCost { get; set; }

        public string? Criminality { get; set; }

        public double? AverageTemperature { get; set; }
    }
}
