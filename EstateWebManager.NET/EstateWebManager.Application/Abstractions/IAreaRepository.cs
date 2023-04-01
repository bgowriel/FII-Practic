using EstateWebManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Abstractions
{
    public interface IAreaRepository
    {
        Task<Area?> GetById(int areaId);
        Task<Area?> GetByNeighborhood(string city, string neighborhood);
        Task<List<Area>?> GetAreasByCity(string city);
        Task<List<Area>?> GetAreasByCountry(string country);
        Task<List<Area>?> GetAll(); 
        Task Insert(Area area);
        void Update(Area area);
        void Delete(Area area);
    }
}
