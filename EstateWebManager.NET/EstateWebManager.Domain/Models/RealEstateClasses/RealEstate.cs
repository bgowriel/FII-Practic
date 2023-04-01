using EstateWebManager.Domain.Enums;
using EstateWebManager.Domain.Models.AppointmentClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace EstateWebManager.Domain.Models.RealEstateClasses
{
    public abstract class RealEstate
    {
        private string _transactionType;

        public int Id { get; set; }

        public string? UserId { get; set; }
        
        public User? User { get; set; }

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

        public Area Area { get; set; }

        [Required]
        public int AreaId { get; set; }

        public DateTime? LastUpdate { get; set; }

        [Required]
        [MaxLength(5)]
        public string TransactionType
        {
            get => _transactionType;
            set
            {
                if (value == "Sale" || value == "Rent") _transactionType = value;
            }
        }

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [Required]
        [MaxLength(15)]
        public string Currency { get; set; }

        public string? PeriodOfTime { get; set; }

        public List<Appointment>? Appointments { get; set; }

        public List<Image>? Images { get; set; }

        public RealEstate() { }

        public override bool Equals(object? obj)
        {
            return obj is RealEstate estate &&
                   Id == estate.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
