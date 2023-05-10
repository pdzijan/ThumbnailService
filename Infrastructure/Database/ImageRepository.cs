using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class ImageRepository : IImageRepository
    {
        private readonly ImageContext _dbContext;

        public ImageRepository(ImageContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> AddImage(Image image)
        {
            var guid = Guid.NewGuid();
            image.ImageUid = guid;
            image.Status = (int)ImageStatus.IN_QUEUE;
            _dbContext.Image.Add(image);
            await _dbContext.SaveChangesAsync();
            return guid;
        }

        public async Task<Image> GetImage(Guid id)
        {
            return await _dbContext.Image.FindAsync(id) ?? new Image();
        }
    }
}
