namespace Application.Interfaces
{
    public interface IImageResizeService
    {
        Task<byte[]> Resize(byte[] stream, int sizeX, int sizeY);
    }
}
