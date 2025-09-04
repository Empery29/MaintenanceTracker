using System.ComponentModel.DataAnnotations;

namespace MaintenanceTracker.Api.DTO
{
    public class LoginDto
    {

        [Required] public string Email { get; set; }

        [Required] public string Password { get; set; }
    }
}
