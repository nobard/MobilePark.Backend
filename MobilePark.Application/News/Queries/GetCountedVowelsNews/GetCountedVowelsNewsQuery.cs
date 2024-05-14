using MediatR;

namespace MobilePark.Application.News.Queries.GetCountedVowelsNews
{
    public class GetCountedVowelsNewsQuery : IRequest<CountedVowelsVm>
    {
        public string KeyWord { get; set; }
        public string FragmentName { get; set;}
        public string Language { get; set; }
    }
}
