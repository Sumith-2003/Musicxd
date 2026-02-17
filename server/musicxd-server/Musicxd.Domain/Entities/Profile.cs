namespace Musicxd.Domain.Entities
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; } // FK
        public string? Username { get; set; } 
        public string? Location { get; set; }
        public string? Website { get; set; }
        public string? Bio { get; set; }

        public User User { get; set; }
        public DateTime DateJoined { get; set; }
        public FavouriteAlbumList FavouriteAlbumList { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<List> Lists { get; set; } = new List<List>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}