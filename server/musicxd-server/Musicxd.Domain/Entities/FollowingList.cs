namespace Musicxd.Domain.Entities
{
    public class FollowingList
    {
        public int ProfileId { get; set; }
        public int FollowingId { get; set; }

        public Profile Profile { get; set; }
        public Profile Following { get; set; }
    }
}