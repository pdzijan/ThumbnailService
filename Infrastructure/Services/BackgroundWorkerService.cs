using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
