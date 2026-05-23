using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Monitoring.Core.Entities;


namespace Monitoring.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Devices => Set<Device>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<EventRuleConfiguration> EventRuleConfigurations => Set<EventRuleConfiguration>();
        public DbSet<EventType> EventTypes => Set<EventType>();
        public DbSet<MonitoringProfile> MonitoringProfiles => Set<MonitoringProfile>();
        public DbSet<Position> Positions => Set<Position>();    
        public DbSet<Route> Routes => Set<Route>();
        public DbSet<RoutePoint> RoutePoints => Set<RoutePoint>();
        public DbSet<Trip> Trips => Set<Trip>();
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<VehicleDevice> VehicleDevices => Set<VehicleDevice>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}