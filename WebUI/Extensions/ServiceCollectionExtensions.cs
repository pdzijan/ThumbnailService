using Application.Interfaces;
using Infrastructure.Database;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IThumbnailService, ThumbnailService>();
            services.AddScoped<IThumbnailRepository, ThumbnailRepository>();
            services.AddScoped<IImageDownloadService, ImageDownloadService>();
            services.AddScoped<IImageResizeService, ImageResizeService>();
            services.AddScoped<IBackgroundWorkerService, BackgroundWorkerService>();
            services.AddHttpClient<IImageDownloadService, ImageDownloadService>();

            return services;
        }
    }
}
