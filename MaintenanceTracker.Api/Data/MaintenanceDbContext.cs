using Microsoft.EntityFrameworkCore;

namespace MaintenanceTracker.Api.Data
{
    public class MaintenanceDbContext : DbContext
    {
        public MaintenanceDbContext(DbContextOptions<MaintenanceDbContext> options) : base(options)
        {

        }

        public DbSet<Maintenance> Maintenances { get; set; }
    }
}
