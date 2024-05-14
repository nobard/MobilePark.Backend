using MobilePark.Application.Interfaces;
using MobilePark.Domain;

namespace MobilePark.Infrastructure.Services
{
    public class DbNewsLogger(IDbContext dbContext)
        : IDbNewsLogger
    {
        private readonly IDbContext _dbContext = dbContext;

        public async Task LogAsync(string keyWord, string language, string fragment, int vowelCount, CancellationToken cancellationToken)
        {
            var log = new NewsRequestLogDomain
            {
                Id = Guid.NewGuid(),
                Keyword = keyWord,
                Fragment = fragment,
                Language = language,
                VowelCount = vowelCount,
                LogDate = DateTime.Now,
            };

            await _dbContext.NewsRequestLogs.AddAsync(log);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
