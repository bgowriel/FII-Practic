using EstateWebManager.Application;
using EstateWebManager.Domain.Models;
using EstateWebManager.Domain.Models.AppointmentClasses;
using EstateWebManager.Domain.Models.RealEstateClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Tests.Unit
{
    [TestFixture]
    public class GeneratorFixture
    {
        private List<Area> areas;
        private List<Flat> flats = new List<Flat>(300);
        private List<Office> offices = new List<Office>(300);
        private List<House> houses = new List<House>(200);
        private List<Land> lands = new List<Land>(200);
        private List<EstateAgent> agents;
        private List<Client> clients;
        private List<Appointment> appointments;

        [SetUp]
        public void Setup()
        {
            areas = Generator.GenerateAreas(10);

            foreach (var area in areas)
            {
                flats.AddRange(Generator.GenerateFlats(30, area));
                offices.AddRange(Generator.GenerateOffices(30, area));
                houses.AddRange(Generator.GenerateHouses(20, area));
                lands.AddRange(Generator.GenerateLands(20, area));
            }
            
            clients = Generator.GenerateClients(200);
            agents = Generator.GenerateAgents(30);
            appointments = Generator.GenerateAppointments(agents, clients, flats, offices, houses, lands);
        }

        [TestCase("Romania")]
        public void AssertAtLeastAThirdOfAreasAreFromMyCountry(string myCountry)
        {
            //Arrange
            int counter = 0;

            //Act
            foreach (var area in areas)
            {
                if (area.Country == myCountry) counter++;
            }

            //Assert
            Assert.That(counter, Is.GreaterThanOrEqualTo(areas.Count / 3));
        }

        [Test]
        public void AssertThatAppointmentsDontOverlap()
        {
            //Arrange
            int duplicate = 0;

            //Act
            foreach (var appointment in appointments)
            {
                List<Appointment> similarAppointments = appointments
                    .Where(a => a.Date == appointment.Date
                                && a.Agent == appointment.Agent
                                && a.Client == appointment.Client)
                    .ToList();
                if (similarAppointments.Count > 1) duplicate++;
            }

            //Assert
            Assert.That(duplicate, Is.EqualTo(0));
        }
    }
}
