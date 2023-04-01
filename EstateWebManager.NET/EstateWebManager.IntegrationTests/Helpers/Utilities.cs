using EstateWebManager.Application;
using EstateWebManager.Application.Commands;
using EstateWebManager.DataAccess;
using EstateWebManager.Domain.Enums;
using EstateWebManager.Domain.Models.AppointmentClasses;
using EstateWebManager.Domain.Models.RealEstateClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace EstateWebManager.IntegrationTests.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(DatabaseContext db)
        {
            db.Areas.AddRange(Generator.GenerateAreas(20));
            db.SaveChanges();

            foreach (var area in db.Areas)
            {
                db.Flats.AddRange(Generator.GenerateFlats(15, area));
                db.Offices.AddRange(Generator.GenerateOffices(15, area));
                db.Houses.AddRange(Generator.GenerateHouses(10, area));
                db.Lands.AddRange(Generator.GenerateLands(10, area));
            }

            db.EstateAgents.AddRange(Generator.GenerateAgents(30));
            db.Clients.AddRange(Generator.GenerateClients(200));
            db.SaveChanges();

            db.Appointments.AddRange(Generator.GenerateAppointments(db.EstateAgents.ToList(),
                                                                    db.Clients.ToList(),
                                                                    db.Flats.ToList(),
                                                                    db.Offices.ToList(),
                                                                    db.Houses.ToList(),
                                                                    db.Lands.ToList()));
            db.SaveChanges();
            if (db.Offices.Any(office => office.Area.City == "Iasi")) Console.WriteLine("We have offices in Iasi! Id: " + db.Offices.First(office => office.Area.City == "Iasi").Id);
        }
    }
}
