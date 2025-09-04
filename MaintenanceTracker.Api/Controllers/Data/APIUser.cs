using Microsoft.AspNetCore.Identity;

namespace MaintenanceTracker.Api.Controllers.Data
{
    public class APIUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
