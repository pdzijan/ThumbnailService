using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class ThumbnailContext : DbContext
    {
        public ThumbnailContext(DbContextOptions<ThumbnailContext> options) : base(options)
        {

        }

        public virtual DbSet<Thumbnail> Thumbnail { get; set; }
    }
}
