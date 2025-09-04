using MaintenanceTracker.Api.Controllers.Data;
using MaintenanceTracker.Api.DTO;
using Microsoft.AspNetCore.Identity;

namespace MaintenanceTracker.Api.Authetication
{
    public class AutoManager : IAutoManager
    {
        private readonly UserManager<APIUser> _userManager;
        public AutoManager(UserManager<APIUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Login(LoginDto loginDto)
        {
            bool isValidUser = false;
            try
            {
                var userExit = await _userManager.FindByEmailAsync(loginDto.Email);
                
                isValidUser = await _userManager.CheckPasswordAsync(userExit, loginDto.Password);
               
            }
            catch (Exception)
            {
                throw;
            }
            return isValidUser;


        }

        public async Task<IEnumerable<IdentityError>> Register(APIUserDto userDto)
        {
            var user = new APIUser
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PasswordHash = userDto.Password,
                UserName = userDto.Email
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            return result.Succeeded ? Array.Empty<IdentityError>() : result.Errors;
        }
    }
}
