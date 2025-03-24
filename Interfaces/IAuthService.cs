using CarRentalApplication.Models.Entities.Users;
using CarRentalApplication.Models.VMs.Auth;
using Microsoft.AspNetCore.Identity;

namespace CarRentalApplication.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterViewModel model);
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
    }
}
