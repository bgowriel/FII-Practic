using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models.RealEstateClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.DataAccess.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OfficeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Office?> GetById(int officeId)
        {
            var office = await _databaseContext.Offices
                .Include(office => office.Area)
                .Include(office => office.Images)
                .SingleOrDefaultAsync(office => office.Id == officeId);
            return office;
        }

        public async Task<List<Office>?> GetByUserId(string userId)
        {
            var office = await _databaseContext.Offices
                .Include(office => office.Area)
                .Include(office => office.Images)
                .Where(office => office.UserId == userId)
                .ToListAsync();
            return office;
        }

        public async Task<List<Office>?> GetAll(string city)
        {
            var offices = await _databaseContext.Offices
                .Include(office => office.Area)
                .Include(office => office.Images)
                .Where(office => office.Area.City == city)
                .Take(4000)
                .ToListAsync();
            return offices;
        }

        public async Task<List<Office>?> GetByPriceRange(string city, int min, int max, string currency)
        {
            var offices = await _databaseContext.Offices
                .Include(office => office.Area)
                .Include(office => office.Images)
                .Where(office => office.Area.City == city
                                 && min <= office.Price
                                 && office.Price <= max
                                 && office.Currency == currency)
                .ToListAsync();
            return offices;
        }

        public async Task<List<Office>?> GetByAddress(string? street, string? city, string country)
        {
            int option = 0;
            if (street != null && city != null) option = 1;
            else if (street == null && city != null) option = 2;
            else option = 3;

            return option switch
            {
                1 => await _databaseContext.Offices
                                        .Include(office => office.Area)
                                        .Include(office => office.Images)
                                        .Where(office => office.Street == street
                                                            && office.Area.City == city
                                                            && office.Area.Country == country)
                                        .ToListAsync(),
                2 => await _databaseContext.Offices
                                        .Include(office => office.Area)
                                        .Include(office => office.Images)
                                        .Where(office => office.Area.City == city
                                                            && office.Area.Country == country)
                                        .ToListAsync(),
                3 => await _databaseContext.Offices
                                        .Include(office => office.Area)
                                        .Include(office => office.Images)
                                        .Where(office => office.Area.Country == country)
                                        .ToListAsync(),
                _ => null,
            };
        }

        public async Task<List<Office>?> GetByMinBuiltUpArea(string city, int minBuiltUpArea)
        {
            var offices = await _databaseContext.Offices
                .Include(office => office.Area)
                .Where(office => office.Area.City == city && minBuiltUpArea <= office.BuiltUpArea)
                .ToListAsync();
            return offices;
        }

        public async Task<List<Office>?> GetByRating(string city, string rating)
        {
            var offices = await _databaseContext.Offices
                .Include(office => office.Area)
                .Where(office => office.Area.City == city && office.Rating == rating)
                .ToListAsync();
            return offices;
        }

        public async Task<List<Office>?> GetWithOptions(string city,
                                                        string rating,
                                                        int minBuiltUpArea,
                                                        bool ac,
                                                        bool internet,
                                                        bool parkingPlace)
        {
            var offices = await _databaseContext.Offices
                .Include(office => office.Area)
                .Include(office => office.Images)
                .Where(office => office.Area.City == city
                                 && office.Rating == rating
                                 && minBuiltUpArea <= office.BuiltUpArea
                                 && office.AC == (ac ? "yes" : "no")
                                 && office.Internet == (internet ? "yes" : "no")
                                 && office.ParkingPlace == (parkingPlace ? "yes" : "no"))
                .ToListAsync();
            return offices;
        }

        public async Task Insert(Office office)
        {
            await _databaseContext.Offices.AddAsync(office);
        }

        public void Update(Office office)
        {
            _databaseContext.Offices.Update(office);
        }

        public void Delete(Office office)
        {
            _databaseContext.Offices.Remove(office);
        }
    }
}
