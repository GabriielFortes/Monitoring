using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoring.Core.Entities;

namespace Monitoring.Infrastructure.Configurations
{
    public class EventRuleConfigurationMap : IEntityTypeConfiguration<EventRuleConfiguration>
    {

        public void Configure(EntityTypeBuilder<EventRuleConfiguration> builder)
        {
            builder.ToTable("EventRuleConfigurations");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

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