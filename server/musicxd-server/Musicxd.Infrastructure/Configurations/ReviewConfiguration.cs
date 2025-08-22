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
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            // Primary Key 
            builder.HasKey(r => r.ReviewId);

            // Properties
            builder.Property(r => r.ReviewId)
                .HasColumnName("review_id")
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Rating)
                .HasColumnName("rating")
                .IsRequired();

            builder.Property(r => r.ReviewDescription)
                .HasColumnName("review_description")
                .HasMaxLength(1000);

            builder.Property(r => r.CreatedDateId)
                .HasColumnType("integer")
                .HasColumnName("created_date_id");

            builder.Property(r => r.UpdatedDateId)
                .HasColumnType("integer")
                .HasColumnName("updated_date_id");

            builder.Property(r => r.ProfileId)
                .HasColumnType("integer")
                .HasColumnName("profile_id");

            builder.Property(r => r.AlbumId)
                .HasColumnType("integer")
                .HasColumnName("album_id");

            // Relationships
            builder.HasOne(r=>r.Profile)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Album)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.CreatedDate)  
                .WithMany(d => d.ReviewsCreated)
                .HasForeignKey(r => r.CreatedDateId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.UpdatedDate)  
                .WithMany(d => d.ReviewsUpdated)
                .HasForeignKey(r => r.UpdatedDateId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(r => r.Comments)
                .WithOne(c => c.Review)
                .HasForeignKey(c => c.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Likes)
                .WithOne(l => l.Review)
                .HasForeignKey(l => l.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("review");
        }
    }
}
