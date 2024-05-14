using Microsoft.EntityFrameworkCore;
using MobilePark.Domain;

namespace MobilePark.Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<NewsRequestLogDomain> NewsRequestLogs { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
