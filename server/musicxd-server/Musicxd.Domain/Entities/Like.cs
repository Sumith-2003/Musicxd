namespace Musicxd.Domain.Entities
{
    public class Like
    {
        public int LikesId { get; set; }
        public int ReviewId { get; set; }
        public int ProfileId { get; set; }

        public Review Review { get; set; }
        public Profile Profile { get; set; }
    }
}