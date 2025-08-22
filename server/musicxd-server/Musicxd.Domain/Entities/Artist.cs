namespace Musicxd.Domain.Entities
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public ICollection<Album> Albums { get; set; }
    }

}
