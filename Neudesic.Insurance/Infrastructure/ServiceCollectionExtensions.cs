using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neudesic.Insurance.Repositories;
using Neudesic.Insurance.ScheduledTasks;
using Neudesic.Insurance.Services;

namespace Neudesic.Insurance.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Extension method to register all dependencies
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Domain Services
            services.AddScoped<IBankService, BankService>();

            // Repository
            services.AddScoped<DbContext, NeudesicInsuranceDataContext>();
            services.AddDbContextPool<NeudesicInsuranceDataContext>(options => options.UseSqlServer(configuration.GetConnectionString("NeudesicInsuranceConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // Infrastructure
            services.AddMemoryCache();
            services.AddScoped<ICache, MemoryCacheAdapter>();

            // Hosted services
            services.AddHostedService<AutomaticPolicyRenewalService>();

            return services;
        }
    }
}
