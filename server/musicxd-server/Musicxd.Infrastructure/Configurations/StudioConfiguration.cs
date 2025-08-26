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
    internal class StudioConfiguration : IEntityTypeConfiguration<Studio>
    {
        public void Configure(EntityTypeBuilder<Studio> builder)
        {
            // Primary Key
            builder.HasKey(s=>s.StudioId);

            // Properties
            builder.Property(s => s.StudioId)
                .ValueGeneratedOnAdd()
                .HasColumnName("studio_id");

            builder.Property(s => s.StudioName)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("studio_name");

            // Relationships
            builder.HasMany(s => s.Albums)
                .WithOne(a => a.Studio)
                .HasForeignKey(a => a.StudioId)
                .OnDelete(DeleteBehavior.Cascade); // one has many and that many has foreign key
                
            // Table name
            builder.ToTable("studio");
        }
    }
}
