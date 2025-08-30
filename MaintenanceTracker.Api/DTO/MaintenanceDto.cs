using MaintenanceTracker.Api.Enums;

namespace MaintenanceTracker.Api.DTO
{
    public class MaintenanceDto
    {
        public int Id { get; set; }
        public string RequestTrackingNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; } = Category.Carpentery;
        public Priority Priority { get; set; } = Priority.Low;
        public Status Status { get; set; } = Status.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
