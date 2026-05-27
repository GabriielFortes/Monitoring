using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoring.Core.Entities;

namespace Monitoring.Infrastructure.Configurations
{
    public class RoutePointConfiguration : IEntityTypeConfiguration<RoutePoint>
    {
        public void Configure(EntityTypeBuilder<RoutePoint> builder)
        {
            builder.ToTable("RoutePoints");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Sequence)
                .IsRequired();

            builder.Property(x => x.Latitude)
                .IsRequired();

            builder.Property(x => x.Longitude)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasIndex(x => x.RouteId);

            builder.HasIndex(x => new
            {
                x.RouteId,
                x.Sequence
            }).IsUnique();

            builder.HasOne<Route>()
                .WithMany()
                .HasForeignKey(x => x.RouteId);
        }
    }
}