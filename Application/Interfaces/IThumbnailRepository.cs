using Domain.Entities;

namespace Application.Interfaces
{
    public interface IThumbnailRepository
    {
        Task<Guid> AddThumbnail(Thumbnail thumbnail);
        Task UpdateThumbnail(Thumbnail thumbnail);
        Task<Thumbnail> GetThumbnail(Guid id);
        Task<Thumbnail?> GetThumbnailForProcess();
    }
}
