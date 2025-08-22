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
                .HasColumnType("integer")
                .ValueGeneratedOnAdd()
                .HasColumnName("genre_id");

            builder.Property(g => g.GenreName)
                .HasColumnName("genre_name");

            builder.HasMany(g=>g.Albums)
                .WithMany(a=>a.Genres);

            builder.ToTable("genre");
        }
    }
}
