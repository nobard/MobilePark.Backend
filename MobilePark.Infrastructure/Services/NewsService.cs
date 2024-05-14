using MobilePark.Application.Interfaces;
using MobilePark.Infrastructure.Models.Configs;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace MobilePark.Infrastructure.Services
{
    public class NewsService(NewsApiConfig config) : INewsService
    {
        private readonly string _apiKey = config.ApiKey;

        public async Task<IList<Article>> GetArticlesAsync(string keyword, string language)
        {
            var request = new EverythingRequest
            {
                Q = keyword,
            };

            switch (language)
            {
                case "ru":
                    request.Language = Languages.RU;
                    break;
                case "en":
                    request.Language = Languages.EN;
                    break;
                default:
                    throw new NotImplementedException($"Язык \"{language}\" не поддерживается");
            }

            var client = new NewsApiClient(_apiKey);
            var articles = await client.GetEverythingAsync(request);

            if (articles.Status != Statuses.Ok) throw new Exception("Ошибка на стороне NewsAPI."); ;

            return articles.Articles.ToList();
        }
    }
}
