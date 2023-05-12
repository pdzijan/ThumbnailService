using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Services
{
    public class BackgroundWorkerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public BackgroundWorkerService(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var backgroundServiceDelay = _configuration.GetSection("BackgroundService").GetValue<int>("BackgroundServiceDelay");
            while (!stoppingToken.IsCancellationRequested)
            {
                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    IThumbnailService scopedProcessingService =
                        scope.ServiceProvider.GetRequiredService<IThumbnailService>();
                    await scopedProcessingService.ProcessThumbnail();
                    await Task.Delay(backgroundServiceDelay);
                }
            }
        }
    }
}
