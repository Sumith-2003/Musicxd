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
            builder.HasKey(f => f.FavouriteAlbumListId);
            builder.Property(f => f.FavouriteAlbumListId)
                .HasColumnName("favourite_album_list_id")
                .ValueGeneratedOnAdd();

            builder.HasOne(f => f.Profile)
                .WithOne(p => p.FavouriteAlbumList)
                .HasForeignKey<FavouriteAlbumList>(f => f.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(f => f.Albums)
                .WithMany(a => a.FavouriteAlbumLists);
            builder.ToTable("favourite_album_lists");
        }
    }
}
