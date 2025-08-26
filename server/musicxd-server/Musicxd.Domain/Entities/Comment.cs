using System.ComponentModel.DataAnnotations.Schema;

namespace Musicxd.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ReviewId { get; set; }
        public int ProfileId { get; set; }
        public string CommentContent { get; set; }
        public int CreatedDateId { get; set; }

        public Date CreatedDate { get; set; }
        [ForeignKey(nameof(ReviewId))]
        public Review Review { get; set; }
        public Profile Profile { get; set; }
    }
}