using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicxd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicxd.Infrastructure.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            // Primary Key
            builder.HasKey(al => al.AlbumId);

            // Properties
            builder.Property(al => al.AlbumId)
                .HasColumnName("album_id")
                .HasColumnType("integer");

            builder.Property(al => al.AlbumName)
                .HasColumnName("album_name")
                .IsRequired();

            builder.Property(al => al.ReleaseDateId)
                .HasColumnName("release_date_id")
                .HasColumnType("integer");

            builder.Property(al => al.CountryName)
                .HasColumnName("country_name");

            builder.Property(al => al.StudioId)
                .HasColumnName("studio_id")
                .HasColumnType("integer");

            builder.Property(al => al.Duration)
                .HasColumnName("duration")
                .HasColumnType("time");

            builder.Property(al => al.AlbumDescription)
                .HasColumnName("album_description");

            // Relationships
            builder.HasOne(al => al.Studio)
                .WithMany(c => c.Albums)
                .HasForeignKey(al => al.StudioId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(al => al.Genres)
                .WithMany(g => g.Albums);

            builder.HasMany(al => al.Artists)
                .WithMany(ar => ar.Albums);

            builder.HasMany(al => al.Reviews)
                .WithOne(r => r.Album)
                .HasForeignKey(r => r.AlbumId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(al => al.Lists)
                .WithMany(l => l.Albums);

            builder.HasOne(al => al.ReleaseDate)
                .WithMany(d => d.Albums)
                .HasForeignKey(a => a.ReleaseDateId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(al => al.FavouriteAlbumLists)
                .WithMany(c => c.Albums);
            
            //Table Name
            builder.ToTable("album");
        }
    }
}
