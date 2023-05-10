using Application.Interfaces;
using Infrastructure.Database;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IImageDownloadService, ImageDownloadService>();

            services.AddDbContextPool<ImageContext>(options => 
                options.UseSqlServer("server=.\\SQLEXPRESS;database=ThumbnailDb;Trusted_Connection=True;TrustServerCertificate=True"));

            services.AddHttpClient<IImageDownloadService, ImageDownloadService>();

            return services;
        }
    }
}
