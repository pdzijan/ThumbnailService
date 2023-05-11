using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ThumbnailService : IThumbnailService
    {
        private readonly IThumbnailRepository _thumbnailRepository;
        private readonly IImageDownloadService _imageDownloadService;
        private readonly IImageResizeService _imageResizeService;
        private readonly IMapper _mapper;

        public ThumbnailService(IThumbnailRepository thumbnailRepository, IImageDownloadService imageDownloadService, IImageResizeService imageResizeService, IMapper mapper)
        {
            _thumbnailRepository = thumbnailRepository;
            _imageDownloadService = imageDownloadService;
            _imageResizeService = imageResizeService;   
            _mapper = mapper;
        }
        public async Task<Guid> AddThumbnail(ThumbnailRequest thumbnailRequest)
        {
            Thumbnail thumbnail = new();
            var guid = Guid.NewGuid();
            thumbnail.ThumbnailUid = guid;
            thumbnail.Url = thumbnailRequest.Url;
            thumbnail.SizeX = thumbnailRequest.SizeX;
            thumbnail.SizeY = thumbnailRequest.SizeY;
            thumbnail.Status = (int)ThumbnailStatus.IN_QUEUE;
            thumbnail.InsertDate = DateTime.Now;
            
            return await _thumbnailRepository.AddThumbnail(thumbnail);
        }

        public async Task<ThumbnailResponse> GetThumbnail(Guid id)
        {
            var thumbnail = await _thumbnailRepository.GetThumbnail(id);
            return new ThumbnailResponse()
            {
                ThumbnailUid = thumbnail.ThumbnailUid,
                Content = thumbnail.Content,
                ErrorMessage = thumbnail.ErrorMessage,
                Status = thumbnail.Status,
            };
        }

        public async Task Updatehumbnail(Thumbnail image)
        {
            await _thumbnailRepository.UpdateThumbnail(image);
        }

        public async Task ProcessThumbnail()
        {
            var thumbnailToProcess = await _thumbnailRepository.GetThumbnailForProcess();
            if (thumbnailToProcess != null && thumbnailToProcess.ThumbnailUid != Guid.Empty)
            {
                var imageContent = await _imageDownloadService.Download(thumbnailToProcess.Url);
                var resizedImage = await _imageResizeService.Resize(imageContent, thumbnailToProcess.SizeX, thumbnailToProcess.SizeY);
                thumbnailToProcess.Content = resizedImage;
                thumbnailToProcess.Status = (int)ThumbnailStatus.COMPLETED;
                await Updatehumbnail(thumbnailToProcess);
            }
        }
    }
}
