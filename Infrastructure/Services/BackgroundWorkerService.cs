using Application.Interfaces;

namespace Infrastructure.Services
{
    public class BackgroundWorkerService : IBackgroundWorkerService
    {
        private readonly IThumbnailService _thumbnailService;

        public BackgroundWorkerService(IThumbnailService thumbnailService)
        {
            _thumbnailService = thumbnailService;
        }
        public async Task ExecuteAsync()
        {
            await _thumbnailService.ProcessThumbnail();
            await Task.Delay(10000);
        }
    }
}
