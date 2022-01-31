using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4HW6.Data;

namespace Module4HW6
{
    public class Queries
    {
        private readonly ApplicationDbContext _context;

        public Queries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Run()
        {
            await FirstQuery();
            await SecondQuery();
            await ThirdQuery();
        }

        public async Task FirstQuery()
        {
            var firstQuery = await _context.Artists
                    .Include(i => i.Songs)
                    .ThenInclude(i => i.Genre)
                    .ToListAsync();

            Console.WriteLine("First query");

            foreach (var artist in firstQuery)
            {
                Console.WriteLine($"Artist: {artist.Name}");

                foreach (var song in artist.Songs)
                {
                    Console.WriteLine($"Song: {song.Title} Genre: {song.Genre.Title}");
                }
            }
        }

        public async Task SecondQuery()
        {
            var secondQuery = await _context.Genres
                .Select(s => new { title = s.Title, count = _context.Songs.Count(c => c.Genre.Title.Equals(s.Title)) })
                .ToListAsync();

            Console.WriteLine("Second query");

            foreach (var genre in secondQuery)
            {
                Console.WriteLine($"Genre: {genre.title} Count of songs: {genre.count}");
            }
        }

        public async Task ThirdQuery()
        {
            var thirdQuery = await _context.Songs
                    .Where(w => w.ReleasedDate < _context.Artists.Max(m => m.DateOfBirth))
                    .ToListAsync();

            Console.WriteLine("Third query");

            foreach (var song in thirdQuery)
            {
                Console.WriteLine($"{song.Title}");
            }
        }
    }
}