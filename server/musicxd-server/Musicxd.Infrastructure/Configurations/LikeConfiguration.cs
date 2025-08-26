using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Musicxd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicxd.Infrastructure.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            // Primary Key
            builder.HasKey(l => l.LikeId);

            // Properties
            builder.Property(l => l.LikeId).
                HasColumnName("like_id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(l => l.ReviewId)
                .HasColumnName("review_id")
                .HasColumnType("int");

            builder.Property(l => l.ProfileId)
                .HasColumnName("profile_id")
                .HasColumnType ("int");

            // Relationships
            builder.HasOne(l => l.Profile)
                .WithMany(p => p.Likes)
                .HasForeignKey("profile_id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(l => l.Review)
                .WithMany(r => r.Likes)
                .HasForeignKey("review_id")
                .OnDelete(DeleteBehavior.NoAction);

            // Table Name
            builder.ToTable("like");
        }
    }
}
