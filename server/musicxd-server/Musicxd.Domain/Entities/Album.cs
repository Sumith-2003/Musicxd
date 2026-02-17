namespace Musicxd.Domain.Entities
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string? AlbumName { get; set; } = string.Empty;
        public string? CountryName { get; set; } = string.Empty;
        public int? StudioId { get; set; }
        public virtual Studio Studio { get; set; }
        public TimeSpan? Duration { get; set; }
        public string? AlbumDescription { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public virtual ICollection<AlbumGenre> AlbumGenres { get; set; } = new List<AlbumGenre>();
        public virtual ICollection<AlbumArtist> AlbumArtists { get; set; } = new List<AlbumArtist>();
        public virtual ICollection<Review> Reviews { get; set; } =  new List<Review>();
        public virtual ICollection<AlbumFavAlbumList> AlbumFavAlbumLists { get; set; } = new List<AlbumFavAlbumList>();
        public virtual ICollection<AlbumList> AlbumLists { get; set; } = new List<AlbumList>();
    }
}
