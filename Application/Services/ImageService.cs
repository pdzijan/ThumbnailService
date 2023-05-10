using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public async Task<Guid> AddImage(Image image)
        {
            return await _imageRepository.AddImage(image);
        }

        public async Task<Image> GetImage(Guid id)
        {
            return await _imageRepository.GetImage(id);
        }
    }
}
