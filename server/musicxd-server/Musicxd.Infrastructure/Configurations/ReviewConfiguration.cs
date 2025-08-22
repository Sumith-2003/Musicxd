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
            builder.HasKey(r => r.ReviewId);
            builder.Property(r => r.ReviewId)
                .HasColumnName("review_id")
                .ValueGeneratedOnAdd();
            builder.Property(r => r.Rating)
                .HasColumnName("rating")
                .IsRequired();
            builder.Property(r => r.ReviewDescription)
                .HasColumnName("review_description")
                .HasMaxLength(1000);

            builder.HasOne(r=>r.Profile)
                .WithMany()
                .HasForeignKey(r => r.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(r => r.Album)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(r => r.CreatedDate)
                .WithMany()
                .HasForeignKey(r => r.CreatedDateId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(r => r.Comments)
                .WithOne(c => c.Review)
                .HasForeignKey(c => c.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(r => r.Likes)
                .WithOne(l => l.Review)
                .HasForeignKey(l => l.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("reviews");
        }
    }
}
