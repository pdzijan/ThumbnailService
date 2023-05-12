using Application.Interfaces;

namespace WebApi.BackgroundWorker
{
    public class BackgroundWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public BackgroundWorker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider; 
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    IBackgroundWorkerService scopedProcessingService =
                        scope.ServiceProvider.GetRequiredService<IBackgroundWorkerService>();

                    await scopedProcessingService.ExecuteAsync();
                }
            }
        }
    }
}
