namespace Musicxd.Domain.Entities
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public int? ReleaseDateId { get; set; }
        public string CountryName { get; set; }
        public int StudioId { get; set; }
        public TimeSpan Duration { get; set; }
        public string AlbumDescription { get; set; }
        public Date ReleaseDate { get; set; }
        public Studio Studio { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Artist> Artists { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<FavouriteAlbumList> FavouriteAlbumLists { get; set; }
        public ICollection<List> Lists { get; set; }
    }
}
