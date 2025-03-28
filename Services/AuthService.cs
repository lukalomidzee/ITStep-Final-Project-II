﻿using CarRentalApplication.Interfaces;
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
        
        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
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

            //await _userManager.AddToRoleAsync(user, "user");
            return await _userManager.CreateAsync(user, model.Password);
        }
    }
}
