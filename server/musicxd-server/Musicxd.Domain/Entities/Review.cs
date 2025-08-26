using System.ComponentModel.DataAnnotations.Schema;

namespace Musicxd.Domain.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int ProfileId { get; set; }
        public int AlbumId { get; set; }
        [ForeignKey(nameof(CreatedDate))]
        public int CreatedDateId { get; set; }
        [ForeignKey(nameof(UpdatedDate))]
        public int? UpdatedDateId { get; set; }
        public int Rating { get; set; } // 1-5
        public string ReviewDescription { get; set; }
        public Profile Profile { get; set; }
        public Album Album { get; set; }
        public Date CreatedDate { get; set; }
        public Date UpdatedDate { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
