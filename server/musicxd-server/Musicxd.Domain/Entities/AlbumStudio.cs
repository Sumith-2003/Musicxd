namespace Musicxd.Domain.Entities
{
    public class AlbumStudio
    {
        public int AlbumId { get; set; }
        public int StudioId { get; set; }

        public Album Album { get; set; }
        public Studio Studio { get; set; }
    }
}
