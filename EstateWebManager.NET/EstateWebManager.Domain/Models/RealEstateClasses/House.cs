using EstateWebManager.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstateWebManager.Domain.Models.RealEstateClasses
{
    public class House : RealEstate
    {
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

        [Range (1, 5)]
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

        public House() { }        
    }
}
