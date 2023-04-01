using EstateWebManager.Domain.Enums;
using EstateWebManager.Domain.Models.RealEstateClasses;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace EstateWebManager.Domain.Models
{
    public class Area
    {
        public int Id { get; set; }
        
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

        [JsonIgnore]
        public List<RealEstate>? RealEstates { get; set; }

        public Area() { }

        public Area(string? neighborhood,
                    string city,
                    string? shortName,
                    string? county,
                    string country,
                    string? phonePrefix,
                    string? continent,
                    string? pollution,
                    string? traffic,
                    string? livingCost,
                    string? criminality,
                    double? averageTemperature)
        {
            Neighborhood = neighborhood;
            City = city;
            ShortName = shortName;
            County = county;
            Country = country;
            PhonePrefix = phonePrefix;
            Continent = continent;
            Pollution = pollution;
            Traffic = traffic;
            LivingCost = livingCost;
            Criminality = criminality;
            AverageTemperature = averageTemperature;
        }

        public override bool Equals(object? obj)
        {
            return obj is Area area &&
                   Id == area.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
