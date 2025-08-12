namespace Musicxd.Domain.Entities
{
    public class Studio
    {
        public int StudioId { get; set; }
        public string StudioName { get; set; }

        public ICollection<AlbumStudio> AlbumStudios { get; set; }
    }
}
