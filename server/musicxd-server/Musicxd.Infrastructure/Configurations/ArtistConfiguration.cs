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
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            // Primary Key
            builder.HasKey(a => a.ArtistId);

            // Properties   
            builder.Property(a => a.ArtistId)
                .HasColumnName("artist_id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .HasColumnName("name");

            builder.Property(a => a.Bio)
                .HasColumnName("bio");

            // Relationships
            builder.HasMany(a => a.Albums)
                .WithMany(al => al.Artists);

            // Table Name
            builder.ToTable("artist");
        }
    }
}