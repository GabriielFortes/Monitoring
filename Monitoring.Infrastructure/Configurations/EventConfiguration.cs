using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoring.Core.Entities;

namespace Monitoring.Infrastructure.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.TripId);

            builder.HasIndex(x => x.EventRuleConfigurationId);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(150);
            
            builder.HasIndex(x => new
            {
                x.TripId,
                x.Id
            });

            builder.HasIndex(x => new
            {
                x.TripId,
                x.EventConfigurationId
            });

            builder.HasOne<Trip>()
                .WithMany()
                .HasForeignKey(x => x.TripId);
            
            builder.HasOne<Trip>()
                .WithMany()
                .HasForeignKey(x => x.TripId);    
        }
    }
}