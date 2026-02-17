namespace Musicxd.Domain.Entities
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Bio { get; set; } = string.Empty;
        public ICollection<AlbumArtist> AlbumArtists { get; set; } = new List<AlbumArtist>();
    }

}
