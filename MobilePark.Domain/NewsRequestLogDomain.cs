namespace MobilePark.Domain
{
    public class NewsRequestLogDomain
    {
        public Guid Id { get; set; }
        public string Keyword { get; set; } = null!;
        public string Fragment { get; set; } = null!;
        public string Language { get; set; } = null!;
        public int VowelCount { get; set; }
        public DateTime LogDate { get; set; }
    }
}
