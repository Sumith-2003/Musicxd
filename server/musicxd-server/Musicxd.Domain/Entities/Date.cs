namespace Musicxd.Domain.Entities
{
    public class Date
    {
        public int DateId { get; set; }
        public DateTime DateValue { get; set; }
        public int Decade { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public ICollection<Album> Albums { get; set; }
        public ICollection<Review> ReviewsCreated { get; set; }
        public ICollection<Review> ReviewsUpdated { get; set; }
        public ICollection<List> ListsCreated { get; set; }
        public ICollection<List> ListsUpdated { get; set; }
        public ICollection<Profile> ProfilesJoined { get; set; }
    }
}
