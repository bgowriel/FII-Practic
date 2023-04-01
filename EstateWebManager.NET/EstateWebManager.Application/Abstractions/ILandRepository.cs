using EstateWebManager.Domain.Models;
using EstateWebManager.Domain.Models.RealEstateClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Abstractions
{
    public interface ILandRepository
    {
        Task<Land?> GetById(int landId);
        Task<List<Land>?> GetAll(string city);
        Task<List<Land>?> GetByPriceRange(string city, int min, int max, string currency);
        Task<List<Land>?> GetByAddress(string? street, string? city, string country);
        Task<List<Land>?> GetByLandArea(string city, int minLandArea, int maxLandArea);
        Task<List<Land>?> GetWithOptions(string city,
                                        int minLandArea,
                                        int maxLandArea,
                                        bool electricity,
                                        bool water,
                                        bool sewerage,
                                        bool heating);
        Task Insert(Land land);
        void Update(Land land);
        void Delete(Land land);
    }
}
