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
        private readonly IImageDownloadService _imageDownloadService;

        public ImageRepository(ImageContext dbContext, IImageDownloadService imageDownloadService)
        {
            _dbContext = dbContext;
            _imageDownloadService = imageDownloadService;
        }
        public async Task<Guid> AddImage(Image image)
        {
            var guid = Guid.NewGuid();
            var imageContent = await _imageDownloadService.Download(image.Url);
            image.ImageUid = guid;
            image.Status = (int)ImageStatus.IN_QUEUE;
            image.TumbnailImage = imageContent;
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
