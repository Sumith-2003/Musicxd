using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicxd.Domain.Entities;

namespace Musicxd.Infrastructure.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            //Primary Key
            builder.HasKey(p => p.ProfileId);

            // Properties
            builder.Property(p => p.ProfileId)
                .HasColumnName("profile_id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Username)
                .HasColumnName("username")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Location)
                .HasColumnName("location")
                .HasMaxLength(100);

            builder.Property(p => p.Website)
                .HasColumnName("website")
                .HasMaxLength(200);

            builder.Property(p => p.Bio)
                .HasColumnName("bio")
                .HasMaxLength(500);

            builder.Property(p=>p.UserId)
                .HasColumnName("user_id")
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.DateJoinedId)
                .HasColumnName("date_joined_id")
                .IsRequired()
                .HasColumnType("int");

            builder.HasIndex(p => p.Username)
               .IsUnique();


            // Relationships
            builder.HasOne(p => p.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<Profile>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.DateJoined)
                .WithMany(d => d.ProfilesJoined)
                .HasForeignKey(p => p.DateJoinedId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.FavouriteAlbumList)
                .WithOne(f => f.Profile)
                .HasForeignKey<FavouriteAlbumList>(f => f.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Reviews)
                .WithOne(r => r.Profile)
                .HasForeignKey(r => r.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Lists)
                .WithOne(l => l.Profile)
                .HasForeignKey(l => l.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Comments)
                .WithOne(c => c.Profile)
                .HasForeignKey(c => c.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Likes)
                .WithOne(l => l.Profile)
                .HasForeignKey(l => l.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // Table Name
            builder.ToTable("profile");
        }
    }
}
