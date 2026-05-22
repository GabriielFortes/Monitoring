
namespace Monitoring.Core.Entities
{
    public class EventRuleConfiguration
    {
        public int Id { get; set; }
        public int EventTypeId { get; set; }
        public int MonitoringProfileId { get; set; }
        public string ConfigurationJson { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}