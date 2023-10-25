using URLShortener.Entities;

namespace URLShortener.Data.Interfaces
{
    public interface IUrlRepository
    {
        Url GetUrlById(int id);
        Url GetUrlByShortUrl(string shortUrl);
        void AddUrl(Url url);
        void SaveChanges();
    }
}
