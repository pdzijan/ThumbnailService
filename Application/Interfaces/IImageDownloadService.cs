namespace Application.Interfaces
{
    public interface IImageDownloadService
    {
        Task<byte[]> Download(string url);
    }
}
