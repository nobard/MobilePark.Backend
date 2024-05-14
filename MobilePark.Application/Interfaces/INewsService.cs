using NewsAPI.Models;

namespace MobilePark.Application.Interfaces
{
    public interface INewsService
    {
        Task<IList<Article>> GetArticlesAsync(string keyword, string language);
    }
}
