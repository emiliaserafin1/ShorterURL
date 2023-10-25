namespace URLShortener.Entities
{
    public class Url
    {
        public int Id { get; set; }
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
        public int ClickCounter { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        
    }
}
