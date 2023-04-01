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
    public class ImageRepository : IImageRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ImageRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Image?> GetById(int imageId)
        {
            var image = await _databaseContext.Images
                .Include(image => image.RealEstate)
                .SingleOrDefaultAsync(image => image.Id == imageId);
            return image;
        }

        public async Task<List<Image>?> GetByRealEstateId(int realEstateId)
        {
            var images = await _databaseContext.Images
                .Where(image => image.RealEstateId == realEstateId)
                .ToListAsync();
            return images;
        }

        public async Task Insert(Image image)
        {
            await _databaseContext.Images.AddAsync(image);
        }

        public void Delete(Image image)
        {
            _databaseContext.Images.Remove(image);
        }
    }
}
