using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Domain.Models.AppointmentClasses
{
    public class EstateAgent
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public ICollection<Appointment>? Appointments { get; set; }

        public EstateAgent() { }

        public override bool Equals(object? obj)
        {
            return obj is EstateAgent agent &&
                   Id == agent.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
