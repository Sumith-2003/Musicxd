namespace Musicxd.Domain.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public ICollection<AlbumCountry> AlbumCountries { get; set; }
    }
}
