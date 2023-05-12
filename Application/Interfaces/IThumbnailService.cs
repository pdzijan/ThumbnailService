using Domain.Entities;
using Domain.Requests;

namespace Application.Interfaces
{
    public interface IThumbnailService
    {
        Task<Guid> AddThumbnail(ThumbnailRequest image);
        Task Updatehumbnail(Thumbnail image);
        Task<ThumbnailResponse> GetThumbnail(Guid id);
        Task ProcessThumbnail();
    }
}
