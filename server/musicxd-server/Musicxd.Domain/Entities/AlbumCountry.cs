namespace Musicxd.Domain.Entities
{
    public class AlbumCountry
    {
        public int AlbumId { get; set; }
        public int CountryId { get; set; }

        public Album Album { get; set; }
        public Country Country { get; set; }
    }
}
