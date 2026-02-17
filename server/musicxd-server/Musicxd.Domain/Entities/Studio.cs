namespace Musicxd.Domain.Entities
{
    public class Studio
    {
        public int StudioId { get; set; }
        public string? StudioName { get; set; }
        public ICollection<Album> Albums { get; set; } = new List<Album>();
    }
}
