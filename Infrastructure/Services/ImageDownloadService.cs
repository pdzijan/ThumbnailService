using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ImageDownloadService : IImageDownloadService
    {
        private readonly HttpClient _client;

        public ImageDownloadService(HttpClient client)
        { 
            _client = client; 
        }

        public async Task<byte[]> Download(string url)
        {
           return await _client.GetByteArrayAsync(url);
        }
    }
}
