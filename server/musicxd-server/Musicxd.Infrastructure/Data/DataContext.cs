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
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Echoes;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //    //var configBuilder = new ConfigurationBuilder().Build();
        //    //configBuilder
        //    //    .AddJsonFile("appsetting.json")
        //    //    .Build();
        //    //var configSection = configBuilder.GetSection("ConnectionStrings");
        //    //var connectionString = configSection["DefaultConnection"] ?? null;
        //    //optionsBuilder.UseSqlServer(connectionString);
        //}

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
        }
    }
}
