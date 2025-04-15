using Microsoft.AspNetCore.Identity;
using SmartStore.Core.Services.Shared.Abstraction;
using SmartStore.Domain.DTOs.Request.Security;
using SmartStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Core.Services.Shared.Implementation
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _emailService;  

        public IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto)
        {
            var user = new ApplicationUser {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                Name = registerDto.Name,
                Id = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                // Send a confirmation email (you'll need to implement email confirmation logic)
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _emailService.SendEmailAsync(user.Email, "Please confirm your email", token);
            }

            return result;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                var token = await _userManager.GenerateUserTokenAsync(user, "Default", "Login");
                return token;
            }

            return null; 
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(changePasswordDto.Email);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found" });

            var result = await _userManager.ChangePasswordAsync(user, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);
            return result;
        }

        public async Task<IdentityResult> SendPasswordResetEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found" });

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _emailService.SendEmailAsync(user.Email, "Reset your password", token);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (result.Succeeded)
            {
                var subject = "Password Reset Successfully";
                var message = "Your password has been reset successfully.";
                await _emailService.SendEmailAsync(user.Email, subject, message);
            }
            return result;
        }
    }
}
