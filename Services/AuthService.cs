using CarRentalApplication.Interfaces;
using CarRentalApplication.Models.Entities.Users;
using CarRentalApplication.Models.VMs.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        //private readonly RoleManager<User> _roleManager;
        
        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager /*RoleManager<User> roleManager*/)
        {
            //_roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.PhoneNumber, model.Password, false, false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.PhoneNumber,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                //if (!await _roleManager.RoleExistsAsync("user"))
                //{
                //    await _roleManager.CreateAsync(new IdentityRole("user"));
                //}

                var roleResult = await _userManager.AddToRoleAsync(user, "user");

                if (!roleResult.Succeeded)
                {
                    foreach (var error in roleResult.Errors)
                    {
                        Console.WriteLine($"Role Assignment Error: {error.Description}");
                    }
                }

                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }
    }
}
