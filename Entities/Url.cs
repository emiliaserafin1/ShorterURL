using System.ComponentModel.DataAnnotations.Schema;

namespace URLShortener.Entities
{
    public class Url
    {
        public int Id { get; set; }
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
        public int ClickCounter { get; set; }
        public Category Category { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public User User { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        
    }
}
