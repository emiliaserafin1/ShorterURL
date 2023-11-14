namespace URLShortener.Models
{
    public class UrlForCreationDto
    {
        public int CategoryId { get; set; }
        public string LongUrl { get; set; }
        public int UserId { get; set; }
    }
}
