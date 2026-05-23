using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring.Core.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public int EventRuleConfigurationId { get; set; }
        public string Description { get; set; } = null!; 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }

}
