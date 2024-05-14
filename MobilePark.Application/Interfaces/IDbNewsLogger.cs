namespace MobilePark.Application.Interfaces
{
    public interface IDbNewsLogger
    {
        Task LogAsync(string keyWord, string language, string fragment, int vowelCount, CancellationToken cancellationToken);
    }
}
