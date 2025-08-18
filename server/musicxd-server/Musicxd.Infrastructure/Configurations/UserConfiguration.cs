using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicxd.Domain.Entities;

namespace Musicxd.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        {
            //Primary Key
            builder.HasKey(u => u.UserId);

            //Properties
            builder.Property(u=> u.UserId)
                .HasColumnName("user_id")
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(u => u.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(256); // Adjust based on your hashing algorithm

            //Indexes
            builder.HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("IX_Users_Email");

            //Relationships
            builder.HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //Table Name
            builder.ToTable("users");
        }
    }
}
