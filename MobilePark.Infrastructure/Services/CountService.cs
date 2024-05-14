using MobilePark.Application.Interfaces;
using System.Text.RegularExpressions;

namespace MobilePark.Infrastructure.Services
{
    public class CountService : ICountService
    {
        public async Task<int> CountVowelsAsync(string fragment)
        {
            if (string.IsNullOrEmpty(fragment)) return 0;

            return await Task.FromResult(Regex.Matches(fragment, @"[aeiouаеёиоуыэюя]", RegexOptions.IgnoreCase).Count);
        }
    }
}
