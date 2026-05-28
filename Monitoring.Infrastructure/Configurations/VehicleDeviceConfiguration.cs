using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoring.Core.Entities;

namespace Monitoring.Infrastructure.Configurations
{
    public class VehicleDeviceConfiguration : IEntityTypeConfiguration<VehicleDevice>
    {
        public void Configure(EntityTypeBuilder<VehicleDevice> builder)
        {
            builder.ToTable("VehicleDevices");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.HasIndex(x => x.VehicleId);

            builder.HasIndex(x => x.DeviceId);

            builder.HasIndex(x => x.AntennaIdentifier)
                .IsUnique();

            builder.HasIndex(x => new
            {
                x.VehicleId,
                x.DeviceId
            }).IsUnique();

            builder.HasOne<Device>()
                .WithMany()
                .HasForeignKey(x => x.DeviceId);
            
            builder.HasOne<Vehicle>()
                .WithMany()
                .HasForeignKey(x => x.VehicleId);

        }
    }
}