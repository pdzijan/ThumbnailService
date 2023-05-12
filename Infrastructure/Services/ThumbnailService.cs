using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Requests;

namespace Infrastructure.Services
{
    public class ThumbnailService : IThumbnailService
    {
        private readonly IThumbnailRepository _thumbnailRepository;
        private readonly IImageDownloadService _imageDownloadService;
        private readonly IImageResizeService _imageResizeService;

        public ThumbnailService(IThumbnailRepository thumbnailRepository, IImageDownloadService imageDownloadService, IImageResizeService imageResizeService)
        {
            _thumbnailRepository = thumbnailRepository;
            _imageDownloadService = imageDownloadService;
            _imageResizeService = imageResizeService;
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
                try
                {
                    var imageContent = await _imageDownloadService.Download(thumbnailToProcess.Url);
                    var resizedImage = await _imageResizeService.Resize(imageContent, thumbnailToProcess.SizeX, thumbnailToProcess.SizeY);
                    thumbnailToProcess.Content = resizedImage;
                    thumbnailToProcess.Status = (int)ThumbnailStatus.COMPLETED;

                    await Updatehumbnail(thumbnailToProcess);
                }
                catch (Exception ex)
                {
                    thumbnailToProcess.Status = (int)ThumbnailStatus.IN_ERROR;
                    thumbnailToProcess.ErrorMessage = ex.Message;

                    await Updatehumbnail(thumbnailToProcess);
                }
            }
        }
    }
}
