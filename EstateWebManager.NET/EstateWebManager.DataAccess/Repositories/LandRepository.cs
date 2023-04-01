using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models.RealEstateClasses;
using Faker;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.DataAccess.Repositories
{
    public class LandRepository : ILandRepository
    {
        private readonly DatabaseContext _databaseContext;

        public LandRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Land?> GetById(int landId)
        {
            var land = await _databaseContext.Lands
                .Include(land => land.Area)
                .SingleOrDefaultAsync(land => land.Id == landId);
            return land;
        }

        public async Task<List<Land>?> GetAll(string city)
        {
            var lands = await _databaseContext.Lands
                .Include(land => land.Area)
                .Where(land => land.Area.City == city)
                .Take(1000)
                .ToListAsync();
            return lands;
        }

        public async Task<List<Land>?> GetByPriceRange(string city, int min, int max, string currency)
        {
            var lands = await _databaseContext.Lands
                .Include(land => land.Area)
                .Where(land => land.Area.City == city
                               && min <= land.Price
                               && land.Price <= max
                               && land.Currency == currency)
                .ToListAsync();
            return lands;
        }

        public async Task<List<Land>?> GetByAddress(string? street, string? city, string country)
        {
            int option = 0;
            if (street != null && city != null) option = 1;
            else if (street == null && city != null) option = 2;
            else option = 3;

            return option switch
            {
                1 => await _databaseContext.Lands
                                        .Include(land => land.Area)
                                        .Where(land => land.Street == street
                                                       && land.Area.City == city
                                                       && land.Area.Country == country)
                                        .ToListAsync(),
                2 => await _databaseContext.Lands
                                        .Include(land => land.Area)
                                        .Where(land => land.Area.City == city
                                                       && land.Area.Country == country)
                                        .ToListAsync(),
                3 => await _databaseContext.Lands
                                        .Include(land => land.Area)
                                        .Where(land => land.Area.Country == country)
                                        .ToListAsync(),
                _ => null,
            };
        }

        public async Task<List<Land>?> GetByLandArea(string city, int minLandArea, int maxLandArea)
        {
            var lands = await _databaseContext.Lands
                .Include(land => land.Area)
                .Where(land => land.Area.City == city
                               && minLandArea <= land.LandArea
                               && land.LandArea <= maxLandArea)
                .ToListAsync();
            return lands;
        }

        public async Task<List<Land>?> GetWithOptions(string city,
                                                      int minLandArea,
                                                      int maxLandArea,
                                                      bool electricity,
                                                      bool water,
                                                      bool sewerage,
                                                      bool heating)
        {
            var lands = await _databaseContext.Lands
                .Include(land => land.Area)
                .Where(land => land.Area.City == city
                            && land.LandArea >= minLandArea
                            && land.LandArea <= maxLandArea
                            && (electricity ? land.Electricity == "yes" : land.Electricity == "no")
                            && (water ? land.Water != "none" : land.Water == "none")
                            && (sewerage ? land.Sewerage != "none" : land.Sewerage == "none")
                            && (heating ? land.Heating != "none" : land.Heating == "none"))
                .ToListAsync();
            return lands;
        }

        public async Task Insert(Land land)
        {
            await _databaseContext.Lands.AddAsync(land);
        }

        public void Update(Land land)
        {
            _databaseContext.Update(land);
        }

        public void Delete(Land land)
        {
            _databaseContext.Lands.Remove(land);
        }
    }
}
