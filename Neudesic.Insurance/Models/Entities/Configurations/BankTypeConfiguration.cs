using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Neudesic.Insurance.Models.Entities.Configurations
{
    public class BankTypeConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(bank => bank.Id);
            builder.Property(bank => bank.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();
        }
    }
}
