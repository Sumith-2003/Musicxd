namespace Musicxd.Domain.Entities
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }  //FK
        public int DateJoinedId { get; set; }  //FK
        public string? Location { get; set; }
        public string? Website { get; set; }
        public string? Bio { get; set; }

        public User User { get; set; } = null!;
        public Date DateJoined { get; set; } = null!;
        public FavouriteAlbumList FavouriteAlbumList { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<List> Lists { get; set; } = new List<List>();
        public ICollection<FollowingList> FollowingLists { get; set; } = new List<FollowingList>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}