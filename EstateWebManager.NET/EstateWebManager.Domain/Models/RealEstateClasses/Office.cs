using EstateWebManager.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstateWebManager.Domain.Models.RealEstateClasses
{
    public class Office : RealEstate
    {
        [Required]
        [MaxLength(10)]
        public string Rating { get; set; }

        [Range(5, 1_000)]
        public int BuiltUpArea { get; set; }

        [MaxLength(50)]
        public string? AC { get; set; } = "yes";

        [MaxLength(50)]
        public string? Internet { get; set; } = "yes";

        [MaxLength(50)]
        public string? ParkingPlace { get; set; } = "yes";

        [Required]
        public DateTime AvailableStarting { get; set; }

        public Office() { }
    }
}
