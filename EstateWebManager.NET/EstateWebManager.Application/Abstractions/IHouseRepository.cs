using EstateWebManager.Domain.Models;
using EstateWebManager.Domain.Models.RealEstateClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Abstractions
{
    public interface IHouseRepository
    {
        Task<House?> GetById(int houseId);
        Task<List<House>?> GetAll(string city);
        Task<List<House>?> GetByPriceRange(string city, int min, int max, string currency);
        Task<List<House>?> GetByTransactionType(string city, string transactionType);
        Task<List<House>?> GetByAddress(string? street, string? city, string country);
        Task<List<House>?> GetByMinAreas(string city, int minBuiltUpArea, int minLandArea);
        Task<List<House>?> GetByMinYearBuilt(string city, int minYearBuilt);
        Task<List<House>?> GetWithOptions(string city,
                                         string transactionType,
                                         int minYearBuilt,
                                         int minBuiltUpArea,
                                         int minLandArea,
                                         int bedrooms,
                                         int bathrooms,
                                         bool ac,
                                         bool internet,
                                         bool garage,
                                         bool swimmingPool);
        Task Insert(House house);
        void Update(House house);
        void Delete(House house);
    }
}
