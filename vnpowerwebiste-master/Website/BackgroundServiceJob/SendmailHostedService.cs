using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Business.IRepostitory;
using Business.Utils;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Website.BackgroundServiceJob
{
    public class SendmailHostedService : IHostedService, IDisposable
    {
        private bool isRunning = false;
        private readonly ILogger<SendmailHostedService> _logger;
        private Timer _timer;
        public IServiceProvider Services { get; }
        public SendmailHostedService(ILogger<SendmailHostedService> logger, IServiceProvider services)
        {
            _logger = logger;
            Services = services;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }
        private void DoWork(object state)
        {
            if (!isRunning)
            {
                isRunning = true;
                using (var scope = Services.CreateScope())
                {
                    var emailSender =
                        scope.ServiceProvider
                            .GetRequiredService<IEmailSender>();
                    var emailRepository =
                       scope.ServiceProvider
                           .GetRequiredService<IEmailRepository>();
                    var data = emailRepository.GetAllData().OrderByDescending(x => x.DateCreated).Take(10).ToList();
                    if (data.Count > 0)
                    {
                        try
                        {
                            foreach (var email in data)
                            {
                                emailSender.SendEmail(email.EmailTo, email.Subject, email.Body, true);
                            }
                            emailRepository.DeleteEntities(data);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.Message);
                        }

                    }

                }
                isRunning = false;

            }

        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

    }
}
