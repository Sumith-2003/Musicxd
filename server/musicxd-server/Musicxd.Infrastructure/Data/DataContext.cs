using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Musicxd.Domain.Entities;
using System;

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
        public DbSet<FavouriteAlbumList> FavouriteAlbumLists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AlbumArtist> AlbumArtists { get; set; }
        public DbSet<AlbumFavAlbumList> AlbumFavAlbumLists { get; set; }
        public DbSet<AlbumList> AlbumLists { get; set; }
        public DbSet<AlbumGenre> AlbumGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // AlbumArtist join table configuration
            modelBuilder.Entity<AlbumArtist>()
                .HasKey(aa => new { aa.AlbumId, aa.ArtistId });

            modelBuilder.Entity<AlbumArtist>()
                .HasOne(aa => aa.Album)
                .WithMany(a => a.AlbumArtists)
                .HasForeignKey(aa => aa.AlbumId);

            modelBuilder.Entity<AlbumArtist>()
                .HasOne(aa => aa.Artist)
                .WithMany(a => a.AlbumArtists)
                .HasForeignKey(aa => aa.ArtistId);

            // AlbumFavAlbumList join table configuration
            modelBuilder.Entity<AlbumFavAlbumList>()
                .HasKey(af => new { af.AlbumId, af.FavouriteAlbumListId });

            modelBuilder.Entity<AlbumFavAlbumList>()
                .HasOne(af => af.Album)
                .WithMany(a => a.AlbumFavAlbumLists)
                .HasForeignKey(af => af.AlbumId);

            modelBuilder.Entity<AlbumFavAlbumList>()
                .HasOne(af => af.FavouriteAlbumList)
                .WithMany(fal => fal.AlbumFavAlbumLists)
                .HasForeignKey(af => af.FavouriteAlbumListId);

            // AlbumList join table configuration
            modelBuilder.Entity<AlbumList>()
                .HasKey(al => new { al.AlbumId, al.ListId });

            modelBuilder.Entity<AlbumList>()
                .HasOne(al => al.Album)
                .WithMany(a => a.AlbumLists)
                .HasForeignKey(al => al.AlbumId);

            modelBuilder.Entity<AlbumList>()
                .HasOne(al => al.List)
                .WithMany(l => l.AlbumLists)
                .HasForeignKey(al => al.ListId);


            // AlbumGenre join table configuration
            modelBuilder.Entity<AlbumGenre>()
                .HasKey(ag => new { ag.AlbumId, ag.GenreId });

            modelBuilder.Entity<AlbumGenre>()
                .HasOne(ag => ag.Album)
                .WithMany(a => a.AlbumGenres)
                .HasForeignKey(ag => ag.AlbumId);

            modelBuilder.Entity<AlbumGenre>()
                .HasOne(ag => ag.Genre)
                .WithMany(g => g.AlbumGenres)
                .HasForeignKey(ag => ag.GenreId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Review)
                .WithMany(r => r.Comments)
                .HasForeignKey(c => c.ReviewId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Review)
                .WithMany(r => r.Likes)
                .HasForeignKey(l => l.ReviewId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Profile)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.ProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<List>()
                .HasOne(l => l.Profile)
                .WithMany(p => p.Lists)
                .HasForeignKey(l => l.ProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Profile>()
                .HasOne(p => p.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<Profile>(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Profile)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Album)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.AlbumId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FavouriteAlbumList>()
                .HasOne(fal => fal.Profile)
                .WithOne(p => p.FavouriteAlbumList)
                .HasForeignKey<FavouriteAlbumList>(fal => fal.ProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            //modelBuilder.ApplyConfiguration<Profile>(new ProfileConfiguration());
            //modelBuilder.ApplyConfiguration<FavouriteAlbumList>(new FavouriteAlbumListConfiguration());
            //modelBuilder.ApplyConfiguration<Album>(new AlbumConfiguration());
            //modelBuilder.ApplyConfiguration<Artist>(new ArtistConfiguration());
            //modelBuilder.ApplyConfiguration<Comment>(new CommentConfiguration());
            //modelBuilder.ApplyConfiguration<Date>(new DateConfiguration());
            //modelBuilder.ApplyConfiguration<Genre>(new GenreConfiguration());
            //modelBuilder.ApplyConfiguration<Like>(new LikeConfiguration());
            //modelBuilder.ApplyConfiguration<List>(new ListConfiguration());
            //modelBuilder.ApplyConfiguration<Review>(new ReviewConfiguration());
            //modelBuilder.ApplyConfiguration<Studio>(new StudioConfiguration());

            // Seed dates for join dates
            //modelBuilder.Entity<Date>().HasData(
            //    new Date { DateId = 1, DateValue = new DateTime(2023, 1, 15), Decade = 2020, Year = 2023, Month = 1, Day = 15 },
            //    new Date { DateId = 2, DateValue = new DateTime(2023, 3, 22), Decade = 2020, Year = 2023, Month = 3, Day = 22 }
            //);

            //// Seed users
            //modelBuilder.Entity<User>().HasData(
            //    new User { UserId = 1, Email = "john.doe@example.com", Password = "Password123!" },
            //    new User { UserId = 2, Email = "jane.smith@example.com", Password = "SecurePass456!" }
            //);

            //// Seed profiles
            //modelBuilder.Entity<Profile>().HasData(
            //    new Profile 
            //    { 
            //        ProfileId = 1, 
            //        UserId = 1, 
            //        Username = "JohnDoe", 
            //        DateJoinedId = 1,
            //        Location = "New York, NY",
            //        Website = "https://johndoe.com",
            //        Bio = "Music enthusiast and vinyl collector"
            //    },
            //    new Profile 
            //    { 
            //        ProfileId = 2, 
            //        UserId = 2, 
            //        Username = "JaneSmith", 
            //        DateJoinedId = 2,
            //        Location = "Los Angeles, CA",
            //        Bio = "Passionate about discovering new artists and genres"
            //    }
            //);
        }
    }
}
