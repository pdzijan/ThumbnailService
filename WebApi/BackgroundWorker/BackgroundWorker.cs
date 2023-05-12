using Application.Interfaces;
using SixLabors.ImageSharp;

namespace WebApi.BackgroundWorker
{
    public class BackgroundWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        public BackgroundWorker(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var beckgroundServiceDelay = _configuration.GetSection("BackgroundService").GetValue<int>("BackgroundServiceDelay");
            while (!stoppingToken.IsCancellationRequested)
            {
                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    IBackgroundWorkerService scopedProcessingService =
                        scope.ServiceProvider.GetRequiredService<IBackgroundWorkerService>();
                    await scopedProcessingService.ExecuteAsync();
                    await Task.Delay(beckgroundServiceDelay);
                }
            }
        }
    }
}
