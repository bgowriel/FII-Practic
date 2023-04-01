using EstateWebManager.Domain.Models;
using EstateWebManager.Domain.Models.RealEstateClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Abstractions
{
    public interface IOfficeRepository
    {
        Task<Office?> GetById(int officeId);
        Task<List<Office>?> GetAll(string city);
        Task<List<Office>?> GetByUserId(string userId);
        Task<List<Office>?> GetByPriceRange(string city, int min, int max, string currency);
        Task<List<Office>?> GetByAddress(string? street, string? city, string country);
        Task<List<Office>?> GetByMinBuiltUpArea(string city, int minBuiltUpArea);
        Task<List<Office>?> GetByRating(string city, string rating);
        Task<List<Office>?> GetWithOptions(string city,
                                           string rating,
                                           int minBuiltUpArea,
                                           bool ac,
                                           bool internet,
                                           bool parkingPlace);
        Task Insert(Office office);
        void Update(Office office);
        void Delete(Office office);
    }
}
