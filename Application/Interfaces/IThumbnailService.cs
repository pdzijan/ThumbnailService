using Domain.Entities;
using Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
