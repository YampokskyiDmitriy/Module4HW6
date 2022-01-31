using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.Data.Entities;

namespace Module4HW6.Data.EntityConfigurations
{
    public class SongConfig : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).ValueGeneratedNever();
            builder.Property(s => s.Title).IsRequired();
            builder.Property(s => s.Duration).IsRequired();
            builder.Property(s => s.ReleasedDate).IsRequired();

            builder.HasOne(g => g.Genre)
                .WithMany(s => s.Songs)
                .HasForeignKey(g => g.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Artists)
                .WithMany(s => s.Songs)
                .UsingEntity<Dictionary<string, object>>(
                "Discography",
                j => j
                .HasOne<Artist>()
                .WithMany()
                .HasForeignKey("ArtistId"),
                j => j
                .HasOne<Song>()
                .WithMany()
                .HasForeignKey("SongId"));
        }
    }
}
