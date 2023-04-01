using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Domain.Models.AppointmentClasses
{
    public class Client
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

        public Client() { }

        public override bool Equals(object? obj)
        {
            return obj is Client client &&
                   Id == client.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
