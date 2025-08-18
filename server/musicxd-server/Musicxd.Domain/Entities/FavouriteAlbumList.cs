namespace Musicxd.Domain.Entities
{
    public class FavouriteAlbumList
    {
        public int FavouriteAlbumListId { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public ICollection<Album> Albums { get; set; } = new List<Album>();
    }
}
