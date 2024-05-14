using Microsoft.EntityFrameworkCore;
using MobilePark.Application.Interfaces;
using MobilePark.Domain;
using MobilePark.Infrastructure.EntityTypeConfiguration;

namespace MobilePark.Infrastructure
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public DbSet<NewsRequestLogDomain> NewsRequestLogs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
            => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NewsRequestLogConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
