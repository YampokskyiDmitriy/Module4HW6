﻿using System;
using System.Collections.Generic;

namespace Module4HW6.Data.Entities
{
    public class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTimeOffset DateOfBirth { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string InstagramUrl { get; set; }

        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
