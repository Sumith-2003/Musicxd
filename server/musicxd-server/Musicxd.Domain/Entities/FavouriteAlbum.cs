namespace Musicxd.Domain.Entities
{
    public class FavouriteAlbum
    {
        public int FavouriteAlbumsId { get; set; }
        public int ProfileId { get; set; }
        public int AlbumId { get; set; }
        public Profile Profile { get; set; }
        public Album Album { get; set; }
    }
}
