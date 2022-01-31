using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module4HW6.Data.Entities;

namespace Module4HW6.Helpers
{
    public class DbInit
    {
        private readonly ApplicationDbContext _context;
        private readonly GoTransaction _transaction;
        private Dictionary<string, Artist> _artists;
        private Dictionary<string, Song> _songs;

        public DbInit(ApplicationDbContext context, GoTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
            _artists = new Dictionary<string, Artist>();
            _songs = new Dictionary<string, Song>();
            Init();
        }

        public async Task InitializeGenreTable()
        {
            await _transaction.ExecuteTransaction(async () =>
            {
                if (!_context.Genres.Any())
                {
                    await _context.Genres.AddAsync(new Genre() { Id = 1, Title = "Rap" });
                    await _context.Genres.AddAsync(new Genre() { Id = 2, Title = "Hip-hop" });
                    await _context.Genres.AddAsync(new Genre() { Id = 3, Title = "SintiPop" });
                    await _context.Genres.AddAsync(new Genre() { Id = 4, Title = "Drill" });
                    await _context.Genres.AddAsync(new Genre() { Id = 5, Title = "Trap" });
                    await _context.SaveChangesAsync();
                }
            });
        }

        public async Task InitializeSongTable()
        {
            await _transaction.ExecuteTransaction(async () =>
            {
                if (!_context.Songs.Any())
                {
                    await _context.Songs.AddAsync(_songs["Fata-Morgana"]);
                    await _context.Songs.AddAsync(_songs["Hop-mechanik"]);
                    await _context.Songs.AddAsync(_songs["DontCry"]);
                    await _context.Songs.AddAsync(_songs["AlreadyDead"]);
                    await _context.Songs.AddAsync(_songs["BigPoppa"]);
                    await _context.SaveChangesAsync();
                }
            });
        }

        public async Task InitializeArtistTable()
        {
            await _transaction.ExecuteTransaction(async () =>
            {
                if (!_context.Songs.Any())
                {
                    await _context.Artists.AddAsync(_artists["Oxxymiron"]);
                    await _context.Artists.AddAsync(_artists["NotoriusBIG"]);
                    await _context.Artists.AddAsync(_artists["Tentacion"]);
                    await _context.Artists.AddAsync(_artists["Markul"]);
                    await _context.Artists.AddAsync(_artists["JuiceWRLD"]);
                    await _context.SaveChangesAsync();
                }
            });
        }

        private void Init()
        {
            _artists.Add("Oxxymiron", new Artist() { Id = 1, Name = "Oxxymiron", DateOfBirth = new DateTimeOffset(new DateTime(1985, 01, 31)), Phone = null, Email = null, InstagramUrl = "https://www.instagram.com/noromixxxo/" });
            _artists.Add("NotoriusBIG", new Artist() { Id = 2, Name = "NotoriusBIG", DateOfBirth = new DateTimeOffset(new DateTime(1972, 5, 21)), Phone = null, Email = null, InstagramUrl = null });
            _artists.Add("Tentacion", new Artist() { Id = 3, Name = "Tentacion", DateOfBirth = new DateTimeOffset(new DateTime(1998, 01, 23)), Phone = null, Email = null, InstagramUrl = null });
            _artists.Add("Markul", new Artist() { Id = 4, Name = "Markul", DateOfBirth = new DateTimeOffset(new DateTime(1993, 03, 31)), Phone = null, Email = null, InstagramUrl = null });
            _artists.Add("JuiceWRLD", new Artist() { Id = 5, Name = "JuiceWRLD", DateOfBirth = new DateTimeOffset(new DateTime(1998, 12, 02)), Phone = null, Email = null, InstagramUrl = null });

            _songs.Add("BigPoppa", new Song() { Id = 5, Title = "BigPoppa", Duration = 200, ReleasedDate = new DateTimeOffset(new DateTime(1950, 12, 12)), GenreId = 2 });
            _songs.Add("Fata-Morgana", new Song() { Id = 1, Title = "Fata-Morgana", Duration = 200, ReleasedDate = new DateTimeOffset(new DateTime(2020, 12, 12)), GenreId = 1 });
            _songs.Add("Hop-mechanik", new Song() { Id = 2, Title = "Hop-mechanik", Duration = 200, ReleasedDate = new DateTimeOffset(new DateTime(2021, 12, 12)), GenreId = 1 });
            _songs.Add("DontCry", new Song() { Id = 3, Title = "DontCry", Duration = 200, ReleasedDate = new DateTimeOffset(new DateTime(2019, 12, 12)), GenreId = 3 });
            _songs.Add("AlreadyDead", new Song() { Id = 4, Title = "AlreadyDead", Duration = 200, ReleasedDate = new DateTimeOffset(new DateTime(2022, 01, 01)), GenreId = 5 });

            _artists["Oxxymiron"].Songs.Add(_songs["Fata-Morgana"]);
            _artists["Oxxymiron"].Songs.Add(_songs["Hop-mechanik"]);
            _artists["NotoriusBIG"].Songs.Add(_songs["BigPoppa"]);
            _artists["Tentacion"].Songs.Add(_songs["DontCry"]);
            _artists["Markul"].Songs.Add(_songs["Fata-Morgana"]);
            _artists["JuiceWRLD"].Songs.Add(_songs["AlreadyDead"]);
        }
    }
}