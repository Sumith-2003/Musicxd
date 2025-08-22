﻿namespace Musicxd.Domain.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
