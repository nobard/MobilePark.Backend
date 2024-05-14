namespace MobilePark.Application.Interfaces
{
    public interface ICountService
    {
        Task<int> CountVowelsAsync(string fragment);
    }
}
