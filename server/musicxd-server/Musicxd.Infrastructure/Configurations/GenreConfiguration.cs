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
    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g=>g.GenreId);

            builder.Property(g => g.GenreId)
                .ValueGeneratedOnAdd()
                .HasColumnName("genre_id");

            builder.Property(g => g.GenreName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("genre_name");

            builder.HasMany(a => a.Albums)
                .WithMany(g => g.Genres);
               
            builder.HasIndex(g => g.GenreName)
              .IsUnique()
              .HasDatabaseName("IX_Genre_GenreName");

        }
    }
}
