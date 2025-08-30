using MaintenanceTracker.Api.Enums;

namespace MaintenanceTracker.Api.DTO
{
    public class UpdateMaintenanceRequestDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Category? Category { get; set; }
        public Priority? Priority { get; set; }
        public Status? Status { get; set; }
    }
}
