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

        }
    }
}
