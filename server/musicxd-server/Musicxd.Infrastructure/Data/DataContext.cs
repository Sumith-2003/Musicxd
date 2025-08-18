using Microsoft.EntityFrameworkCore;
using Musicxd.Domain.Entities;
using Musicxd.Infrastructure.Configurations;

namespace Musicxd.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumCountry> AlbumCountries { get; set; }
        public DbSet<AlbumGenre> AlbumGenres { get; set; }
        public DbSet<AlbumStudio> AlbumStudios { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CreatedBy> CreatedBys { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<FavouriteAlbumList> FavouriteAlbumLists { get; set; }
        public DbSet<FollowingList> FollowingLists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        }
    }
}
