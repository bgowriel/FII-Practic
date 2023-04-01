using EstateWebManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Abstractions
{
    public interface IImageRepository
    {
        Task<Image?> GetById(int id);

        Task<List<Image>?> GetByRealEstateId(int realEstateId);

        Task Insert(Image image);

        void Delete(Image image);
    }
}
