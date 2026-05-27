using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoring.Core.Entities;


namespace Monitoring.Infrastructure.Configurations
{
    public class TripStatusConfiguration : IEntityTypeConfiguration<TripStatus>
    {
        public void Configure(EntityTypeBuilder<TripStatus> builder)
        {
            builder.ToTable("TripStatus");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

        }
    }
}
