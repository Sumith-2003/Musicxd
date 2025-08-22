using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicxd.Domain.Entities;

namespace Musicxd.Infrastructure.Configurations
{
    public class ListConfiguration : IEntityTypeConfiguration<List>
    {
        public void Configure(EntityTypeBuilder<List> builder)
        {
            builder.HasKey(l => l.ListId);
            builder.Property(l => l.ListId)
                .HasColumnName("list_id")
                .ValueGeneratedOnAdd();
            builder.Property(builder => builder.ListName)
                .HasColumnName("list_name")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(l=> l.ListDescription)
                .HasColumnName("list_description")
                .HasMaxLength(500);

            builder.HasOne(l => l.Profile)
                .WithMany(p => p.Lists)
                .HasForeignKey(l => l.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(l => l.CreatedDate)
                .WithMany()
                .HasForeignKey(l => l.CreatedDateId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(l => l.UpdatedDate)
                .WithMany()
                .HasForeignKey(l => l.UpdatedDateId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(l => l.Albums)
                .WithMany(a => a.Lists);
            builder.ToTable("lists");

        }
    }
}
