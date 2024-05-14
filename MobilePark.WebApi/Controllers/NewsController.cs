using Microsoft.AspNetCore.Mvc;
using MobilePark.Application.News.Queries.GetCountedVowelsNews;
using MobilePark.Domain.Enums;

namespace MobilePark.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : BaseController
    {
        [HttpGet("countVowels")]
        public async Task<ActionResult<CountedVowelsVm>> GetCountedVowelsNews(string keyWord, string fragmentName, Language language, CancellationToken cancellationToken)
        {
            var query = new GetCountedVowelsNewsQuery
            {
                KeyWord = keyWord,
                FragmentName = fragmentName,
                Language = language.ToString(),
            };

            var vm = await Mediator.Send(query, cancellationToken);

            return Ok(vm);
        }
    }
}
