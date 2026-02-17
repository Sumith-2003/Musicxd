namespace Musicxd.Domain.Entities
{
    public class FavouriteAlbumList
    {
        public int FavouriteAlbumListId { get; set; }
        public int ProfileId { get; set; } //FK
        public Profile Profile { get; set; }
        public ICollection<AlbumFavAlbumList> AlbumFavAlbumLists { get; set; } = new List<AlbumFavAlbumList>();
    }
}
