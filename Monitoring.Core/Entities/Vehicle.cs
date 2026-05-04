using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring.Core.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DeviceId { get; set; }
        public int Antenna { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}