using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IThumbnailRepository
    {
        Task<Guid> AddThumbnail(Thumbnail thumbnail);
        Task UpdateThumbnail(Thumbnail thumbnail);
        Task<Thumbnail> GetThumbnail(Guid id);
        Task<Thumbnail> GetThumbnailForProcess();
    }
}
