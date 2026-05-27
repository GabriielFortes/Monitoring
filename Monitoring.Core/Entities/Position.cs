using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Monitoring.Core.Entities
{
    public class Position
    {
        public long Id { get; set; }
        public int VehicleDeviceId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Speed { get; set; }
        public double Heading { get; set; } 
        public DateTime Timestamp { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}