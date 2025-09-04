using MaintenanceTracker.Api.DTO;
using Microsoft.AspNetCore.Identity;

namespace MaintenanceTracker.Api.Authetication
{
    public interface IAutoManager
    {
        Task<IEnumerable<IdentityError>> Register(APIUserDto userDto);

        Task<bool> Login(LoginDto loginDto);
    }
}
