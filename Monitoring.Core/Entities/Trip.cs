using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring.Core.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int MonitoringProfileId { get; set; }
        public int RouteId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    
    }
}