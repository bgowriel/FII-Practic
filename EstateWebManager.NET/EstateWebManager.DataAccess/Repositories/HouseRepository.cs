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
    public class HouseRepository : IHouseRepository
    {
        private readonly DatabaseContext _databaseContext;

        public HouseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<House?> GetById(int houseId)
        {
            var house = await _databaseContext.Houses
                .Include(house => house.Area)
                .SingleOrDefaultAsync(house => house.Id == houseId);
            return house;
        }

        public async Task<List<House>?> GetAll(string city)
        {
            var houses = await _databaseContext.Houses
                .Include(house => house.Area)
                .Where(house => house.Area.City == city)
                .Take(1000)
                .ToListAsync();
            return houses;
        }

        public async Task<List<House>?> GetByPriceRange(string city, int min, int max, string currency)
        {
            var houses = await _databaseContext.Houses
                .Include(house => house.Area)
                .Where(house => house.Area.City == city
                                && min <= house.Price
                                && house.Price <= max
                                && house.Currency == currency)
                .ToListAsync();
            return houses;
        }

        public async Task<List<House>?> GetByTransactionType(string city, string transactionType)
        {
            var houses = await _databaseContext.Houses
                .Include(house => house.Area)
                .Where(house => house.Area.City == city
                                && house.TransactionType == transactionType)
                .ToListAsync();
            return houses;
        }

        public async Task<List<House>?> GetByAddress(string? street, string? city, string country)
        {
            int option = 0;
            if (street != null && city != null) option = 1;
            else if (street == null && city != null) option = 2;
            else option = 3;

            return option switch
            {
                1 => await _databaseContext.Houses
                                        .Include(house => house.Area)
                                        .Where(house => house.Street == street
                                                            && house.Area.City == city
                                                            && house.Area.Country == country)
                                        .ToListAsync(),
                2 => await _databaseContext.Houses
                                        .Include(house => house.Area)
                                        .Where(house => house.Area.City == city
                                                            && house.Area.Country == country)
                                        .ToListAsync(),
                3 => await _databaseContext.Houses
                                        .Include(house => house.Area)
                                        .Where(house => house.Area.Country == country)
                                        .ToListAsync(),
                _ => null,
            };
        }

        public async Task<List<House>?> GetByMinAreas(string city, int minBuiltUpArea, int minLandArea)
        {
            var houses = await _databaseContext.Houses
                .Include(house => house.Area)
                .Where(house => house.Area.City == city
                                && house.BuiltUpArea >= minBuiltUpArea
                                && house.LandArea >= minLandArea)
                .ToListAsync();
            return houses;
        }

        public async Task<List<House>?> GetByMinYearBuilt(string city, int minYearBuilt)
        {
            var houses = await _databaseContext.Houses
                .Include(house => house.Area)
                .Where(house => house.Area.City == city && house.YearBuilt >= minYearBuilt)
                .ToListAsync();
            return houses;
        }

        public async Task<List<House>?> GetWithOptions(string city,
                                                       string transactionType,
                                                       int minYearBuilt,
                                                       int minBuiltUpArea,
                                                       int minLandArea,
                                                       int bedrooms,
                                                       int bathrooms,
                                                       bool ac,
                                                       bool internet,
                                                       bool garage,
                                                       bool swimmingPool)
        {
            var houses = await _databaseContext.Houses
                .Include(house => house.Area)
                .Where(house => house.Area.City == city
                                && house.TransactionType == transactionType
                                && house.YearBuilt >= minYearBuilt
                                && house.BuiltUpArea >= minBuiltUpArea
                                && house.LandArea >= minLandArea
                                && house.Bedrooms >= bedrooms
                                && house.Bathrooms >= bathrooms
                                && house.AC == (ac ? "yes" : "no")
                                && house.Internet == (internet ? "yes" : "no")
                                && house.Garage == (garage ? "yes" : "no")
                                && house.SwimmingPool == (swimmingPool ? "yes" : "no"))
                .ToListAsync();
            return houses;
        }

        public async Task Insert(House house)
        {
            await _databaseContext.Houses.AddAsync(house);
        }

        public void Update(House house)
        {
            _databaseContext.Houses.Update(house);
        }

        public void Delete(House house)
        {
            _databaseContext.Houses.Remove(house);
        }
    }
}
