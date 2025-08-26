using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicxd.Domain.Entities;

namespace Musicxd.Infrastructure.Configurations
{
    public class FavouriteAlbumListConfiguration : IEntityTypeConfiguration<FavouriteAlbumList>
    {
        public void Configure(EntityTypeBuilder<FavouriteAlbumList> builder)
        {
            // Primary Key
            builder.HasKey(f => f.FavouriteAlbumListId);

            // Properties
            builder.Property(f => f.FavouriteAlbumListId)
                .HasColumnType("integer")
                .HasColumnName("favourite_album_list_id")
                .ValueGeneratedOnAdd();

            builder.Property(f => f.ProfileId)
                .HasColumnType("integer")
                .HasColumnName("profile_id");

            // Relationships
            builder.HasOne(f => f.Profile)
                .WithOne(p => p.FavouriteAlbumList)
                .HasForeignKey<FavouriteAlbumList>(f => f.ProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(f => f.Albums)
                .WithMany(a => a.FavouriteAlbumLists);

            // Table name
            builder.ToTable("favourite_album_list");
        }
    }
}
