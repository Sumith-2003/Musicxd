namespace Musicxd.Domain.Entities
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int DateJoinedId { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public string Bio { get; set; }
        public User User { get; set; }
        public Date DateJoined { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<FavouriteAlbum> FavouriteAlbums { get; set; }
        public ICollection<List> Lists { get; set; }
        public ICollection<FollowingList> FollowingLists { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}