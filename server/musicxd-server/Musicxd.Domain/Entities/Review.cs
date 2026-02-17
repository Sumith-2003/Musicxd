using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musicxd.Domain.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int ProfileId { get; set; } //FK
        public int AlbumId { get; set; } //FK
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [Range(1, 5)]
        public int? Rating { get; set; } // 1-5
        public string? ReviewDescription { get; set; }
        public Profile Profile { get; set; }
        public Album Album { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}
