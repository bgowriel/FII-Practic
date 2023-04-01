using EstateWebManager.Application.Abstractions;
using EstateWebManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.DataAccess.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly DatabaseContext _databaseContext;

        public AreaRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Area?> GetById(int areaId)
        {
            var area = await _databaseContext.Areas
                .IgnoreAutoIncludes()
                .SingleOrDefaultAsync(area => area.Id == areaId);
            return area;
        }
        
        public async Task<List<Area>?> GetAll()
        {
            var areas = await _databaseContext.Areas
                .Take(100)
                .ToListAsync();
            return areas;
        }

        public async Task<Area?> GetByNeighborhood(string city, string neighborhood)
        {
            var area = await _databaseContext.Areas
                .SingleOrDefaultAsync(a => a.City == city && a.Neighborhood == neighborhood);
            return area;
        }

        public async Task<List<Area>?> GetAreasByCity(string city)
        {
            var areas = await _databaseContext.Areas
                .Where(area => area.City == city)
                .ToListAsync();
            return areas;
        }

        public async Task<List<Area>?> GetAreasByCountry(string country)
        {
            var areas = await _databaseContext.Areas
                .Where(area => area.Country == country)
                .ToListAsync();
            return areas;
        }

        public async Task Insert(Area area)
        {
            await _databaseContext.Areas.AddAsync(area);
        }

        public void Update(Area area)
        {
            _databaseContext.Areas.Update(area);
        }

        public void Delete(Area area)
        {
            _databaseContext.Areas.Remove(area);
        }
    }
}
