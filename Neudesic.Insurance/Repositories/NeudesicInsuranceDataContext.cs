using Microsoft.EntityFrameworkCore;
using Neudesic.Insurance.Models.Entities;
using Neudesic.Insurance.Models.Entities.Configurations;

namespace Neudesic.Insurance.Repositories
{
    public class NeudesicInsuranceDataContext : DbContext
    {
        private readonly DbContextOptions<NeudesicInsuranceDataContext> _options;

        public NeudesicInsuranceDataContext(DbContextOptions<NeudesicInsuranceDataContext> options) : base(options)
        {
            _options = options;
        }

        public virtual DbSet<Bank> Banks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Load all entity type configurations from assembly
            // This will help to keep entities POCO
            builder.ApplyConfigurationsFromAssembly(new BankTypeConfiguration().GetType().Assembly);
            
            base.OnModelCreating(builder);
        }
    }
}
