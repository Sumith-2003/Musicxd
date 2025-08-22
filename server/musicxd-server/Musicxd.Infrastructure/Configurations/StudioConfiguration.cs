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

            
            builder.HasMany(a=>a.Albums)
                .WithOne(s=>s.Studio)
                .HasForeignKey(s => s.StudioId) 
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(s => s.StudioName)
               .IsUnique()
               .HasDatabaseName("IX_Studio_StudioName");



            builder.ToTable("studio");

        }
    }
}
