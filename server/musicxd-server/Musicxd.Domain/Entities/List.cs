using System.ComponentModel.DataAnnotations.Schema;

namespace Musicxd.Domain.Entities
{
    public class List
    {
        public int ListId { get; set; }
        public int ProfileId { get; set; } //FK
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? ListDescription { get; set; }
        public string? ListName { get; set; }
        public Profile Profile { get; set; }
        public ICollection<AlbumList> AlbumLists { get; set; }
    }
}
