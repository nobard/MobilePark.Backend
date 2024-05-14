using MediatR;
using MobilePark.Application.Interfaces;
using MobilePark.Application.NewsRequestLog.Commands;
using NewsAPI.Models;
using System.Reflection;

namespace MobilePark.Application.News.Queries.GetCountedVowelsNews
{
    public class GetCountedVowelsNewsQueryHandler(INewsService newsService, ICountService countService, IMediator mediator)
        : IRequestHandler<GetCountedVowelsNewsQuery, CountedVowelsVm>
    {
        private readonly INewsService _newsService = newsService;
        private readonly ICountService _countService = countService;
        private readonly IMediator _mediator = mediator;

        public async Task<CountedVowelsVm> Handle(GetCountedVowelsNewsQuery request, CancellationToken cancellationToken)
        {
            var articles = await _newsService.GetArticlesAsync(request.KeyWord, request.Language);
            var property = typeof(Article).GetProperty(request.FragmentName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property is null) throw new Exception($"Фрагмента {request.FragmentName} не существует.");

            var countedNews = new List<CountedVowel>();

            foreach (var article in articles)
            {
                if (article is null) continue;

                var fragment = property.GetValue(article).ToString();
                var count = await _countService.CountVowelsAsync(fragment);

                countedNews.Add(new CountedVowel { Fragment = fragment, Count = count });

                var command = new CreateNewsRequestLogCommand
                {
                    KeyWord = request.KeyWord,
                    Language = request.Language,
                    Fragment = fragment,
                    VowelCount = count,
                };

                await _mediator.Send(command, cancellationToken);
            }

            return new CountedVowelsVm
            {
                CountedVowelsNews = countedNews
                    .OrderByDescending(item => item.Count)
                    .ToList()
            };
        }
    }
}
