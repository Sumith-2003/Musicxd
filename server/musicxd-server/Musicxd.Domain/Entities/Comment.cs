using System.ComponentModel.DataAnnotations.Schema;

namespace Musicxd.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int? ReviewId { get; set; }
        public int? ProfileId { get; set; }
        public string? CommentContent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Review Review { get; set; }
        public Profile Profile { get; set; }
    }
}