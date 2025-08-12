namespace Musicxd.Domain.Entities
{
    public class AlbumGenre
    {
        public int AlbumId { get; set; }
        public int GenreId { get; set; }

        public Album Album { get; set; }
        public Genre Genre { get; set; }
    }
}
