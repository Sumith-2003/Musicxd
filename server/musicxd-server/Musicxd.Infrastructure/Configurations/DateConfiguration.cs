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
    public class DateConfiguration : IEntityTypeConfiguration<Date> 
    {
        public void Configure(EntityTypeBuilder<Date> builder)
        {
            // Primary Key
            builder.HasKey(d => d.DateId);

            // Properties
            builder.Property(d => d.DateId)
                .HasColumnName("date_id")
                .HasColumnType("integer");

            builder.Property(d => d.DateValue)
                .HasColumnName("date_value")
                .HasColumnType("date");

            builder.Property(d => d.Decade)
                .HasColumnName("decade")
                .HasColumnType("integer");

            builder.Property(d => d.Year)
                .HasColumnName("year")
                .HasColumnType("integer");

            builder.Property(d => d.Month)
                .HasColumnName("month")
                .HasColumnType("integer");

            builder.Property(d => d.Day)
                .HasColumnName("day")
                .HasColumnType("integer");

            //Relationships
            builder.HasMany(d=>d.Albums)
                .WithOne(a => a.ReleaseDate)
                .HasForeignKey(a => a.ReleaseDateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.ProfilesJoined)
                .WithOne(p => p.DateJoined)
                .HasForeignKey(p => p.DateJoinedId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.ReviewsCreated)
                .WithOne(r => r.CreatedDate)
                .HasForeignKey(r => r.CreatedDateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.Comments)
                .WithOne(c => c.CreatedDate)
                .HasForeignKey(c => c.CreatedDateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d=>d.ListsCreated)
                .WithOne(l => l.CreatedDate)
                .HasForeignKey(l => l.CreatedDateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.ListsUpdated)
                .WithOne(l => l.UpdatedDate)
                .HasForeignKey(l => l.UpdatedDateId)
                .OnDelete(DeleteBehavior.Restrict);

            // Table name
            builder.ToTable("date");
        }
    }
}
