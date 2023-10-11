using Microsoft.EntityFrameworkCore;
using URLShortener.Entities;

namespace URLShortener.Data
{
    public class UrlShortenerContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }

        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) { } //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
    }

}
