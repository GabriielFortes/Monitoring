using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoring.Core.Entities;

namespace Monitoring.Infrastructure.Configurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("Trips");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.HasIndex(x => x.VehicleId);

            builder.HasIndex(x => x.MonitoringProfileId);

            builder.HasIndex(x => x.RouteId);

            builder.HasIndex(x => x.TripStatusId);

            builder.HasOne<TripStatus>()
                .WithMany()
                .HasForeignKey(x => x.TripStatusId);

            builder.HasOne<Vehicle>()
                .WithMany()
                .HasForeignKey(x => x.VehicleId);

            builder.HasOne<MonitoringProfile>()
                .WithMany()
                .HasForeignKey(x => x.MonitoringProfileId);
            
            builder.HasOne<Route>()
                .WithMany()
                .HasForeignKey(x => x.RouteId);

        }
    }
}