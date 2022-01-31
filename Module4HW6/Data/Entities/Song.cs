using System;
using System.Collections.Generic;

namespace Module4HW6.Data.Entities
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Duration { get; set; }

        public DateTimeOffset ReleasedDate { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual List<Artist> Artists { get; set; } = new List<Artist>();
    }
}
