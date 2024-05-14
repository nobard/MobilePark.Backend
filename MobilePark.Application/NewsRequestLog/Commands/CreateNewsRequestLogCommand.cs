using MediatR;

namespace MobilePark.Application.NewsRequestLog.Commands
{
    public class CreateNewsRequestLogCommand : IRequest
    {
        public string KeyWord { get; set; }
        public string Language { get; set; }
        public string Fragment { get; set; }
        public int VowelCount { get; set; }
    }
}
