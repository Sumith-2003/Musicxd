namespace Musicxd.Domain.Entities
{
    public class Album
    {
        public int AlbumId { get; set; }
        public int? GenreId { get; set; }
        public string AlbumName { get; set; }
        public int? ReleaseDateId { get; set; }
        public string Length { get; set; }
        public string AlbumDescription { get; set; }

        public Genre Genre { get; set; }
        public Date ReleaseDate { get; set; }

        public ICollection<AlbumGenre> AlbumGenres { get; set; }
        public ICollection<AlbumCountry> AlbumCountries { get; set; }
        public ICollection<AlbumStudio> AlbumStudios { get; set; }
        public ICollection<CreatedBy> CreatedBys { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<FavouriteAlbum> FavouriteAlbums { get; set; }
        public ICollection<List> Lists { get; set; }
    }
}
