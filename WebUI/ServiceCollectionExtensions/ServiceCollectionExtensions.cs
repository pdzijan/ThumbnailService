using Application.Interfaces;
using Application.Validators;
using Domain.Requests;
using FluentValidation;
using Infrastructure.Database;
using Infrastructure.Services;

namespace WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IThumbnailService, ThumbnailService>();
            services.AddScoped<IThumbnailRepository, ThumbnailRepository>();
            services.AddScoped<IImageDownloadService, ImageDownloadService>();
            services.AddScoped<IImageResizeService, ImageResizeService>();
            services.AddScoped<IBackgroundWorkerService, BackgroundWorkerService>();
            services.AddScoped<IValidator<ThumbnailRequest>, ThumbnailRequestValidator>();
            services.AddHttpClient<IImageDownloadService, ImageDownloadService>();

            return services;
        }
    }
}
