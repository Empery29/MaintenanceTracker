using MaintenanceTracker.Api.Authetication;
using MaintenanceTracker.Api.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAutoManager _autoManager;
        public AccountController(IAutoManager autoManager)
        {
            _autoManager = autoManager;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] APIUserDto userDto)
        {
            var errors = await _autoManager.Register(userDto);
            if (errors.Any())
            {

                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest("User  unsuccessfully");
            }
           
            return Ok(errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _autoManager.Login(loginDto);
            if (!result)
            {
                return Unauthorized("Invalid Authentication");
            }
            return Ok(new { Message = "Login Successful" });
        }
    }
}
