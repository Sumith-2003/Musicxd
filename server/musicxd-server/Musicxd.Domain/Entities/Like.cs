namespace Musicxd.Domain.Entities
{
    public class Like
    {
        public int LikeId { get; set; }
        public int ReviewId { get; set; } //FK
        public int ProfileId { get; set; } //FK

        public Review Review { get; set; }
        public Profile Profile { get; set; }
    }
}