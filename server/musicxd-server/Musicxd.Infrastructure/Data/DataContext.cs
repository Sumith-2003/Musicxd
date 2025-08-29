using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<FavouriteAlbumList> FavouriteAlbumLists { get; set; }
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
            modelBuilder.ApplyConfiguration<Profile>(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration<FavouriteAlbumList>(new FavouriteAlbumListConfiguration());
            modelBuilder.ApplyConfiguration<Album>(new AlbumConfiguration());
            modelBuilder.ApplyConfiguration<Artist>(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration<Comment>(new CommentConfiguration());
            modelBuilder.ApplyConfiguration<Date>(new DateConfiguration());
            modelBuilder.ApplyConfiguration<Genre>(new GenreConfiguration());
            modelBuilder.ApplyConfiguration<Like>(new LikeConfiguration());
            modelBuilder.ApplyConfiguration<List>(new ListConfiguration());
            modelBuilder.ApplyConfiguration<Review>(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration<Studio>(new StudioConfiguration());
            
            // Seed dates for join dates
            modelBuilder.Entity<Date>().HasData(
                new Date { DateId = 1, DateValue = new DateTime(2023, 1, 15), Decade = 2020, Year = 2023, Month = 1, Day = 15 },
                new Date { DateId = 2, DateValue = new DateTime(2023, 3, 22), Decade = 2020, Year = 2023, Month = 3, Day = 22 }
            );
            
            // Seed users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Email = "john.doe@example.com", Password = "Password123!" },
                new User { UserId = 2, Email = "jane.smith@example.com", Password = "SecurePass456!" }
            );

            // Seed profiles
            modelBuilder.Entity<Profile>().HasData(
                new Profile 
                { 
                    ProfileId = 1, 
                    UserId = 1, 
                    Username = "JohnDoe", 
                    DateJoinedId = 1,
                    Location = "New York, NY",
                    Website = "https://johndoe.com",
                    Bio = "Music enthusiast and vinyl collector"
                },
                new Profile 
                { 
                    ProfileId = 2, 
                    UserId = 2, 
                    Username = "JaneSmith", 
                    DateJoinedId = 2,
                    Location = "Los Angeles, CA",
                    Bio = "Passionate about discovering new artists and genres"
                }
            );
        }
    }
}
