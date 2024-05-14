using MediatR;
using MobilePark.Application.Interfaces;

namespace MobilePark.Application.NewsRequestLog.Commands
{
    public class CreateNewsRequestLogCommandHandler(IDbNewsLogger dbLogger)
        : IRequestHandler<CreateNewsRequestLogCommand>
    {
        private readonly IDbNewsLogger _dbLogger = dbLogger;

        public async Task Handle(CreateNewsRequestLogCommand request, CancellationToken cancellationToken)
        {
            await _dbLogger.LogAsync(request.KeyWord, request.Language, request.Fragment, request.VowelCount, cancellationToken);
        }
    }
}
