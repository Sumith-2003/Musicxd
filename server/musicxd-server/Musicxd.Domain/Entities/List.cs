namespace Musicxd.Domain.Entities
{
    public class List
    {
        public int ListId { get; set; }
        public int ProfileId { get; set; }
        public int AlbumId { get; set; }
        public int CreatedDateId { get; set; }
        public int? UpdatedDateId { get; set; }
        public string ListDescription { get; set; }

        public Profile Profile { get; set; }
        public Album Album { get; set; }
        public Date CreatedDate { get; set; }
        public Date UpdatedDate { get; set; }
    }
}
