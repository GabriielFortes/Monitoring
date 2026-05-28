using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoring.Core.Entities;

namespace Monitoring.Infrastructure.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Latitude)
                .IsRequired();

            builder.Property(x => x.Longitude)
                .IsRequired();

            builder.Property(x => x.Speed)
                .IsRequired();

            builder.Property(x => x.Timestamp)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();
            
            builder.Property(x => x.Latitude)
                .HasPrecision(9, 6);

            builder.Property(x => x.Longitude)
                .HasPrecision(9, 6);

            builder.HasIndex(x => x.VehicleDeviceId);

            builder.HasIndex(x => x.Timestamp);

            builder.HasIndex(x => new
            {
                x.VehicleDeviceId,
                x.Timestamp
            });

            builder.HasOne<VehicleDevice>()
                .WithMany()
                .HasForeignKey(x => x.VehicleDeviceId);
        }
    }
}