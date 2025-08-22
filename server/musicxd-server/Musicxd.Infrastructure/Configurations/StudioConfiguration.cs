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
            builder.HasKey(s=>s.StudioId);

            builder.Property(s => s.StudioId)
                .ValueGeneratedOnAdd()
                .HasColumnName("studio_id");

            builder.Property(s => s.StudioName)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("studio_name");

            builder.HasMany(s => s.Albums)
                .WithOne(a => a.Studio)
                .HasForeignKey(a => a.StudioId); // one has many and that many has foreign key
                
            builder.ToTable("studio");
        }
    }
}
