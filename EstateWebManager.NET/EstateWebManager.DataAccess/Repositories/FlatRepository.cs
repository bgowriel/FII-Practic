using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models;
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
    public class FlatRepository : IFlatRepository
    {
        private readonly DatabaseContext _databaseContext;

        public FlatRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Flat?> GetById(int flatId)
        {
            var flat = await _databaseContext.Flats
                .Include(flat => flat.Area)
                .SingleOrDefaultAsync(flat => flat.Id == flatId);
            return flat;
        }

        public async Task<List<Flat>?> GetAll(string city)
        {
            var flats = await _databaseContext.Flats
                .Include(flat => flat.Area)
                .Where(flat => flat.Area.City == city)
                .Take(1000)
                .ToListAsync();
            return flats;
        }

        public async Task<List<Flat>?> GetByPriceRange(string city, int min, int max, string currency)
        {
            var flats = await _databaseContext.Flats
                .Include(flat => flat.Area)
                .Where(flat => flat.Area.City == city
                               && min <= flat.Price
                               && flat.Price <= max
                               && flat.Currency == currency)
                .ToListAsync();
            return flats;
        }

        public async Task<List<Flat>?> GetByTransactionType(string city, string transactionType)
        {
            var flats = await _databaseContext.Flats
                .Include(flat => flat.Area)
                .Where(flat => flat.Area.City == city && flat.TransactionType == transactionType)
                .ToListAsync();
            return flats;
        }

        public async Task<List<Flat>?> GetByAddress(string? street, string? city, string country)
        {
            int option = 0;
            if (street != null && city != null) option = 1;
            else if (street == null && city != null) option = 2;
            else option = 3;

            return option switch
            {
                1 => await _databaseContext.Flats
                                        .Include(flat => flat.Area)
                                        .Where(flat => flat.Street == street
                                                            && flat.Area.City == city
                                                            && flat.Area.Country == country)
                                        .ToListAsync(),
                2 => await _databaseContext.Flats
                                        .Include(flat => flat.Area)
                                        .Where(flat => flat.Area.City == city
                                                            && flat.Area.Country == country)
                                        .ToListAsync(),
                3 => await _databaseContext.Flats
                                        .Include(flat => flat.Area)
                                        .Where(flat => flat.Area.Country == country)
                                        .ToListAsync(),
                _ => null,
            };
        }

        public async Task<List<Flat>?> GetByMinBuiltUpArea(string city, int minBuiltUpArea)
        {
            var flats = await _databaseContext.Flats
                .Include(flat => flat.Area)
                .Where(flat => flat.Area.City == city && minBuiltUpArea <= flat.BuiltUpArea)
                .ToListAsync();
            return flats;
        }

        public async Task<List<Flat>?> GetWithOptions(string city,
                                                     string transactionType,
                                                     int bedrooms,
                                                     int bathrooms,
                                                     bool ac,
                                                     bool internet,
                                                     bool parkingPlace)
        {
            var flats = await _databaseContext.Flats
                .Include(flat => flat.Area)
                .Where(flat => flat.Area.City == city
                            && flat.TransactionType == transactionType
                            && bedrooms == flat.Bedrooms
                            && bathrooms == flat.Bathrooms
                            && flat.AC == (ac ? "yes" : "no")
                            && flat.Internet == (internet ? "yes" : "no")
                            && flat.ParkingPlace == (parkingPlace ? "yes" : "no"))
                .ToListAsync();
            return flats;
        }

        public async Task Insert(Flat flat)
        {
            await _databaseContext.Flats.AddAsync(flat);
        }

        public void Update(Flat flat)
        {
            _databaseContext.Flats.Update(flat);
        }

        public void Delete(Flat flat)
        {
            _databaseContext.Flats.Remove(flat);
        }
    }
}
