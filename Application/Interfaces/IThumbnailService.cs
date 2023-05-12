using Domain.Entities;
using Domain.Requests;

namespace Application.Interfaces
{
    public interface IThumbnailService
    {
        Task<Guid> AddThumbnail(ThumbnailRequest image);
        Task UpdateThumbnail(Thumbnail image);
        Task<ThumbnailResponse> GetThumbnail(Guid id);
        Task ProcessThumbnail();
    }
}
