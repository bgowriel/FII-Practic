using EstateWebManager.Domain.Models.RealEstateClasses;
using Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Abstractions
{
    public interface IFlatRepository
    {
        Task<Flat?> GetById(int flatId);
        Task<List<Flat>?> GetAll(string city);
        Task<List<Flat>?> GetByPriceRange(string city, int min, int max, string currency);
        Task<List<Flat>?> GetByTransactionType(string city, string transactionType);
        Task<List<Flat>?> GetByAddress(string? street, string? city, string country);
        Task<List<Flat>?> GetByMinBuiltUpArea(string city, int minBuiltUpArea);
        Task<List<Flat>?> GetWithOptions(string city,
                                        string transactionType,
                                        int bedrooms,
                                        int bathrooms,
                                        bool ac,
                                        bool internet,
                                        bool parkingPlace);
        Task Insert(Flat flat);
        void Update(Flat flat);
        void Delete(Flat flat);
    }
}
