using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoring.Core.Entities;

namespace Monitoring.Infrastructure.Configurations
{
    public class EventRuleConfiguration : IEntityTypeConfiguration<Monitoring.Core.Entities.EventRuleConfiguration>
    {

        public void Configure(EntityTypeBuilder<Monitoring.Core.Entities.EventRuleConfiguration> builder)
        {
            builder.ToTable("EventConfigurations");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.EventTypeId);

            builder.HasIndex(x => x.MonitoringProfileId);

            builder.HasIndex(x => new
            {
                x.MonitoringProfileId,
                x.EventTypeId
            }).IsUnique();

            builder.HasOne<MonitoringProfile>()
                .WithMany()
                .HasForeignKey(x => x.MonitoringProfileId);

            builder.HasOne<EventType>()
                .WithMany()
                .HasForeignKey(x => x.EventTypeId);
        }
    }
}