using EstateWebManager.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstateWebManager.Domain.Models.RealEstateClasses
{
    public class Land : RealEstate
    {
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

        public Land() { }
    }
}
