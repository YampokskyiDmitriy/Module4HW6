using Microsoft.EntityFrameworkCore;
using Module4HW6.Data.Entities;
using Module4HW6.Data.EntityConfigurations;

namespace Module4HW6
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
            : base(contextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfig());
            modelBuilder.ApplyConfiguration(new SongConfig());
            modelBuilder.ApplyConfiguration(new GenreConfig());
        }
    }
}