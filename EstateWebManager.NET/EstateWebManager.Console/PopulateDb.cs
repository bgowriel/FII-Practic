using EstateWebManager.Application;
using EstateWebManager.DataAccess;
using EstateWebManager.Domain.Models.RealEstateClasses;
using EstateWebManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateWebManager.Domain.Models.AppointmentClasses;
using Microsoft.EntityFrameworkCore;

namespace EstateWebManager.ConsoleApp
{
    public class PopulateDb
    {
        public PopulateDb() { }
        public static async Task WithMockData()
        {
            List<Area> areas = Generator.GenerateAreas(30);
            List<Flat> flats = new(300);
            List<Office> offices = new(900);
            List<House> houses = new(300);
            List<Land> lands = new(300);

            List<EstateAgent> agents = new(30);
            List<Client> clients = new(200);
            List<Appointment> appointments = new(150);

            foreach (Area area in areas)
            {
                flats.AddRange(Generator.GenerateFlats(15, area));
                offices.AddRange(Generator.GenerateOffices(30, area));
                houses.AddRange(Generator.GenerateHouses(10, area));
                lands.AddRange(Generator.GenerateLands(10, area));
            }
            

            var databaseContext = new DatabaseContext();

            await databaseContext.AddRangeAsync(areas);
            await databaseContext.AddRangeAsync(flats);
            await databaseContext.AddRangeAsync(offices);
            await databaseContext.AddRangeAsync(houses);
            await databaseContext.AddRangeAsync(lands);

            await databaseContext.SaveChangesAsync();

            flats = await databaseContext.Flats.ToListAsync();
            offices = await databaseContext.Offices.ToListAsync();
            houses = await databaseContext.Houses.ToListAsync();
            lands = await databaseContext.Lands.ToListAsync();

            var estates = new List<RealEstate>(1500);
            estates.AddRange(flats);
            estates.AddRange(offices);
            estates.AddRange(houses);
            estates.AddRange(lands);

            var images = Generator.GenerateImages(estates);
            await databaseContext.AddRangeAsync(images);
            await databaseContext.SaveChangesAsync();
            
            agents.AddRange(Generator.GenerateAgents(30));
            clients.AddRange(Generator.GenerateClients(200));
            appointments.AddRange(Generator.GenerateAppointments(agents,
                                                                 clients,
                                                                 flats,
                                                                 offices,
                                                                 houses,
                                                                 lands));
            

            await databaseContext.AddRangeAsync(agents);
            await databaseContext.AddRangeAsync(clients);
            await databaseContext.AddRangeAsync(appointments);

            await databaseContext.SaveChangesAsync();
        }
    }
}
