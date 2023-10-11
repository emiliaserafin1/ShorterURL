namespace URLShortener.Models
{
    public class UrlResponseDto
    {
        public int Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreationDate { get; set; }
        public int ClickCount { get; set; }
    }

}
