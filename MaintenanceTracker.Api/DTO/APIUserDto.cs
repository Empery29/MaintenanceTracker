using System.ComponentModel.DataAnnotations;

namespace MaintenanceTracker.Api.DTO
{
    public class APIUserDto
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        [Required] public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmedPassword{ get; set; }
    }
}
