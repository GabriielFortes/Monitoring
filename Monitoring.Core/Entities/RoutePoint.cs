using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring.Core.Entities
{
    public class RoutePoint
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int Sequence { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}