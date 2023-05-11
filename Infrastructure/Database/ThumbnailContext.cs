using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
