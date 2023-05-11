using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class ThumbnailRepository : IThumbnailRepository
    {
        private readonly ThumbnailContext _dbContext;

        public ThumbnailRepository(ThumbnailContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> AddThumbnail(Thumbnail thumbnail)
        {
            _dbContext.Thumbnail.Add(thumbnail);
            await _dbContext.SaveChangesAsync();
            return thumbnail.ThumbnailUid;
        }

        public async Task<Thumbnail> GetThumbnail(Guid id)
        {
            return await _dbContext.Thumbnail.FindAsync(id) ?? new Thumbnail();
        }

        public async Task<Thumbnail> GetThumbnailForProcess()
        {
            return await _dbContext.Thumbnail
                .Where(o => o.Status == (int)ThumbnailStatus.IN_QUEUE)
                .OrderByDescending(o => o.InsertDate)
                .FirstOrDefaultAsync() ?? new Thumbnail();
        }

        public async Task UpdateThumbnail(Thumbnail thumbnail)
        {
            _dbContext.Thumbnail.Update(thumbnail);
            await _dbContext.SaveChangesAsync();
        }
    }
}
