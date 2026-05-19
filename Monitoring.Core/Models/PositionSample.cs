using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring.Core.Models
{
    public class PositionSample
    {
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}