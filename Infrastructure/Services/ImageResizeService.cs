using Application.Interfaces;

namespace Infrastructure.Services
{
    public class ImageResizeService : IImageResizeService
    {
        public async Task<byte[]> Resize(byte[] stream, int sizeX, int sizeY)
        {
            using (var memoryStream = new MemoryStream())
            {
                using var image = Image.Load(stream);
                image.Mutate(x => x.Resize(sizeX, sizeY));
                await image.SaveAsJpegAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
