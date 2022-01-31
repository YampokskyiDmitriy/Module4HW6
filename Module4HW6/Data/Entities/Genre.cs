using System.Collections.Generic;

namespace Module4HW6.Data.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public List<Song> Songs { get; set; } = new List<Song>();
    }
}