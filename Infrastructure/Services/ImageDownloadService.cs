using Application.Interfaces;

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
            try
            {
                return await _client.GetByteArrayAsync(url);
            }
            catch 
            {
                throw new Exception("ERROR_DOWNLOADING_IMAGE");
            }
        }
    }
}
