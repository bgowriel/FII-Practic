using EstateWebManager.Application;
using EstateWebManager.Application.Abstractions;
using EstateWebManager.DataAccess;
using EstateWebManager.DataAccess.Repositories;
using EstateWebManager.Domain.Enums;
using EstateWebManager.Domain.Models;
using EstateWebManager.Domain.Models.AppointmentClasses;
using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text;

namespace EstateWebManager.ConsoleApp
{
    public class TestingApp
    {
        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            StreamWriter ErrorLog = new StreamWriter($@"{Directory.GetCurrentDirectory()}\ErrorAndDBLog.txt");
            Console.SetError(ErrorLog);

            var databaseContext = new DatabaseContext();

            //DELETE DB, CREATE DB, GENERATE AND POPULATE WITH MOCK DATA
            {
                databaseContext.Database.EnsureDeleted();
                databaseContext.Database.EnsureCreated();
                await PopulateDb.WithMockData();
            }
            
        }        
    }
}
