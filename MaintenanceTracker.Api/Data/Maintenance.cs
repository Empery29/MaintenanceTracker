using MaintenanceTracker.Api.Enums;

namespace MaintenanceTracker.Api.Data
{
    public class Maintenance
    {
        public int Id { get; set; }
        public string RequestTrackingNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; } = Status.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
