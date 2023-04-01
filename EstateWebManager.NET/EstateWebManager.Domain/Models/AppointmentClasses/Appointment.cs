using EstateWebManager.Domain.Models.RealEstateClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Domain.Models.AppointmentClasses
{
    public class Appointment
    {
        [ForeignKey("Agent")]
        public int AgentId { get; set; }

        public EstateAgent Agent { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        [ForeignKey("RealEstate")]
        public int RealEstateId { get; set; }

        public RealEstate RealEstate { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public Appointment() { }

        public Appointment(EstateAgent agent, Client client, RealEstate realEstate, DateTime date)
        {
            Agent = agent;
            Client = client;
            RealEstate = realEstate;
            Date = date;
        }

        public override bool Equals(object? obj)
        {
            return obj is Appointment appointment &&
                   AgentId == appointment.AgentId &&
                   ClientId == appointment.ClientId &&
                   RealEstateId == appointment.RealEstateId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AgentId, ClientId, RealEstateId);
        }
    }
}
