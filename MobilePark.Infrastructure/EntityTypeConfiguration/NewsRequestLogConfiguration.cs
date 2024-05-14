using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobilePark.Domain;

namespace MobilePark.Infrastructure.EntityTypeConfiguration
{
    public class NewsRequestLogConfiguration : IEntityTypeConfiguration<NewsRequestLogDomain>
    {
        public void Configure(EntityTypeBuilder<NewsRequestLogDomain> builder)
        {
            builder.ToTable("NewsRequestLogs")
                .HasKey(log => log.Id);

            builder.HasIndex(log => log.Id)
                .IsUnique();
        }
    }
}
