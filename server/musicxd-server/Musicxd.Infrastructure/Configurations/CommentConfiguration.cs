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
    internal class CommentConfiguration :IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Primary Key
            builder.HasKey(c => c.CommentId);

            // Properties
            builder.Property(c => c.CommentId)
                .HasColumnType("integer")
                .ValueGeneratedOnAdd()
                .HasColumnName("comment_id");

            builder.Property(c => c.CreatedDateId)
                .HasColumnType("integer")
                .HasColumnName("created_date_id");

            builder.Property(c => c.ReviewId)
                .HasColumnType("integer")
                .HasColumnName("review_id");

            builder.Property(c => c.ProfileId)
                .HasColumnType("integer")
                .HasColumnName("profile_id");

            builder.Property(c => c.CommentContent)
                .HasColumnName("comment_content");

            // Relationships
            builder.HasOne(c => c.Profile)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.ProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.CreatedDate)
                .WithMany(d => d.Comments)
                .HasForeignKey(d => d.CreatedDateId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Review)
                .WithMany(r => r.Comments)
                .HasForeignKey(c => c.ReviewId)
                .OnDelete(DeleteBehavior.NoAction);

            // Table name
            builder.ToTable("comment");
        }
    }
}
