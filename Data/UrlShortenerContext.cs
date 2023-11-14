using Microsoft.EntityFrameworkCore;
using URLShortener.Entities;

namespace URLShortener.Data
{
    public class UrlShortenerContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }  
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) { } //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Urls)
                .WithOne(u => u.Category)
                .HasForeignKey(u => u.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Redes sociales" },
                new Category() { Id = 2, Name = "Plataforma streaming" },
                new Category() { Id = 3, Name = "Peliculas" }
            );

            modelBuilder.Entity<User>()
                .HasMany(u => u.Urls)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);
            base.OnModelCreating(modelBuilder);
        }
    }

}
