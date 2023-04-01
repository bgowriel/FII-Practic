using EstateWebManager.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstateWebManager.Domain.Models.RealEstateClasses
{
    public class Flat : RealEstate
    {
        [Range(0, 200)]
        public int BuiltUpArea { get; set; }

        [Range(0, 5)]
        public int Bedrooms { get; set; }

        [Range (0, 3)]
        public int Bathrooms { get; set; }

        [MaxLength(50)]
        public string? Heating { get; set; } = "individual gas heating station";

        [MaxLength(50)]
        public string? AC { get; set; } = "no";

        [MaxLength(50)]
        public string? Internet { get; set; } = "yes";

        [MaxLength(50)]
        public string? ParkingPlace { get; set; } = "no";

        [Required]
        public DateTime AvailableStarting { get; set; }

        public Flat() { }
    }
}
