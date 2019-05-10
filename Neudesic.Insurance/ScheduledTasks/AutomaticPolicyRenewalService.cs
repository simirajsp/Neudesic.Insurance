using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Neudesic.Insurance.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Neudesic.Insurance.ScheduledTasks
{
    public class AutomaticPolicyRenewalService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public AutomaticPolicyRenewalService(IServiceProvider provider)
        {
            _serviceProvider = provider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                await BuyPolicyForNonInsuredLoans(stoppingToken);

                // Wait for a day before executing next
                // This can be further tuned to execute on specific time each day if needed
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken); 
            }
        }

        private async Task BuyPolicyForNonInsuredLoans(CancellationToken stoppingToken)
        {
            var taskFactory = new TaskFactory(TaskScheduler.Current);

            await taskFactory.StartNew(() => 
            {
                // Separate scope is required as this is executed in separate thread
                using (var scope = _serviceProvider.CreateScope())
                {
                    IPolicyRenewalService renewalService = scope.ServiceProvider.GetRequiredService<IPolicyRenewalService>();
                    renewalService.RenewExpiredPolicies();
                }

            }, stoppingToken);

        }
    }
}
